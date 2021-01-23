    public class Foo
    {        
        public int Ean { get; set; }
        public string Titre { get; set; }
        public int Prix { get; set; }
        public int Quantite { get; set; }
    }
    List<Foo> lst = new List<Foo>();
        
    Foo f = new  Foo();
    f.Ean = Convert.ToInt32(txtStockEAN.Text);
    f.Titre = txtStockTitre.Text;
    f.Prix = Convert.ToInt32(txtStockPrix.Text);
    f.Quantite = Convert.ToInt32(txtStockQuantite.Text);
    lst.Add(f);
