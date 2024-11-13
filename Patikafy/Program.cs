namespace Patikafy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Sanatci> sanatcilar = new List<Sanatci> //Sanatçılar listelendi
{
    new Sanatci { Ad = "Ajda Pekkan",  MuzikTuru = "Pop",  CikisYili = 1968, AlbumSatislari = 20000000 },
    new Sanatci { Ad = "Sezen Aksu",  MuzikTuru = "Türk HAlk müziği/Pop",  CikisYili = 1971, AlbumSatislari = 10000000 },
    new Sanatci { Ad = "Funda Arar",  MuzikTuru = "Pop",  CikisYili = 1999, AlbumSatislari = 3000000 },
    new Sanatci { Ad = "Sertab Erener",  MuzikTuru = "Pop",  CikisYili = 1994, AlbumSatislari = 5000000 },
    new Sanatci { Ad = "Sıla",  MuzikTuru = "Pop",  CikisYili = 2009, AlbumSatislari = 3000000 },
    new Sanatci { Ad = "Serdar Ortaç",  MuzikTuru = "Pop",  CikisYili = 1994, AlbumSatislari = 10000000 },
    new Sanatci { Ad = "Tarkan",  MuzikTuru = "Pop",  CikisYili = 1992, AlbumSatislari = 40000000 },
    new Sanatci { Ad = "Hande Yener",  MuzikTuru = "Pop",  CikisYili = 1999, AlbumSatislari = 7000000 },
    new Sanatci { Ad = "Hadise",  MuzikTuru = "Pop",  CikisYili = 2005, AlbumSatislari = 5000000 },
    new Sanatci { Ad = "Gülben Ergen",  MuzikTuru = "Pop/Türk Halk Müziği",  CikisYili = 1997, AlbumSatislari = 10000000 },
    new Sanatci { Ad = "Neşet Ertaş",  MuzikTuru = "Türk Halk Müziği/Türk Sanat Müziği",  CikisYili = 1960, AlbumSatislari = 2000000 }

};
            var sIleBaslayanlar = sanatcilar.Where(s => s.Ad.StartsWith("S")); // adı 'S' ile başlayanlar where ile filtrelendi
            foreach (var sanatci in sIleBaslayanlar)
            {
                Console.WriteLine($"Adı: {sanatci.Ad}");// Adı S ile başlayanlar ekrana yazıldırıldı
            }
            //Albüm Satışı 10 milyondan fazla olanlar filtrelendi
            var cokSatanlar = sanatcilar.Where(s => s.AlbumSatislari > 10000000);
            foreach (var sanatci in cokSatanlar)
            {
                Console.WriteLine($"Adı: {sanatci.Ad} , Satış Miktarı: {sanatci.AlbumSatislari}");
            }
            //2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar. ( Çıkış yıllarına göre gruplayarak, alfabetik bir sıra ile yazdırıldı. )
            var eskiPopcular = sanatcilar.Where(s => s.CikisYili < 2000 && s.MuzikTuru == "Pop")
                                         .GroupBy(s => s.CikisYili)
                                         .OrderBy(g => g.Key)
                                         .Select(g => new { Yil = g.Key, Sanatcilar = g });
            foreach (var grup in eskiPopcular)
            {
                Console.WriteLine($"** {grup.Yil} Yılında Çıkış Yapan Pop Sanatçılar:**");
                foreach (var sanatci in grup.Sanatcilar)
                {
                    Console.WriteLine($"  - {sanatci.Ad}");
                }
            }
            // En çok albüm satan şarkıcı azalana göre sıralayıp ilk sıradaki şarkıcıyı ekrana yazdırır.
            var enCokSatan = sanatcilar.OrderByDescending(s => s.AlbumSatislari).First();

            Console.WriteLine($"\nEn Çok Satan Sanatçı:");
            Console.WriteLine($"Adı: {enCokSatan.Ad}");
            Console.WriteLine($"Albüm Satışları: {enCokSatan.AlbumSatislari}");
            
            //azalana göre sıralama yapıp birinci şarkıcıyı ekrana yazdırır.
            var enYeni = sanatcilar.OrderByDescending(s => s.CikisYili).First();
            //artana göre sıralama yapıp ilk şarkıyı ekrana yazdırır.
            var enEski = sanatcilar.OrderBy(s => s.CikisYili).First();

            Console.WriteLine("\nEn Yeni Sanatçı:");
            Console.WriteLine($"Adı: {enYeni.Ad}");
            Console.WriteLine($"Çıkış Yılı: {enYeni.CikisYili}");

            Console.WriteLine("\nEn Eski Sanatçı:");
            Console.WriteLine($"Adı: {enEski.Ad}");
            Console.WriteLine($"Çıkış Yılı: {enEski.CikisYili}");
        }
    }
}
