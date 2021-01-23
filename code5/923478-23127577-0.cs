    public class Leden
    {
            public Leden() //Leden Contructor
            {
            }
    
        // Metodes
        public void ChangeAanmeldDatum()
        {
            AanmeldDatum = DateTime.Now;
        }
    
        public int Lidnummer {get; set;}
        public string Naam {get; set;}
        public string AchterNaam {get; set;}
        public bool Geslacht {get; set;}
        public string Leeftijd {get; set;}
        public DateTime AanmeldDatum {get; set;}
    }
