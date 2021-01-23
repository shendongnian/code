    void Main()
    {
        List<Artikel> Minlista = new List<Artikel>();
        Minlista.Add(new Artikel 
                         { Varonamn = "Mjölk", Pris = "14.90", 
                           kategori = new Kategori 
                           {KategoriID = "1", Namn = "Kategori Name"} 
                          });
    }
