    class Blogimerkinta
    {
        string teksti;
        string[] avainsanat;
        public string Teksti { get; set; }
        public string[] Avainsanat { get; set; }
        public Blogimerkinta(string otsikko)
        {
            this.teksti = otsikko;
        }
    }
