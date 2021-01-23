    class Blogimerkinta
    {
        string teksti;
        string[] avainsanat;
        
        public Blogimerkinta(){} // This is parameterless constructor
        public Blogimerkinta(string input)
        {
            if(input != null)
                teksti = input; //You initialize class fields here or do other stuff
        }
        public string Teksti { get; set; }
        public string[] Avainsanat { get; set; }
    }
