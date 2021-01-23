    public class Leden
    {
        public Leden() //Leden Contructor <-- here you were missing '()'
        {
            // do stuff in your constructor...
        }
        // Metodes <-- these are commonly called properties
        public int Lidnummer {get; set;}
        public string Naam {get; set;}
        public string AchterNaam {get; set;}
        public bool Geslacht {get; set;}
        public string Leeftijd {get; set;}
        public Datetime AanmeldDatum {get; set;}
    } // <-- you had one '}' too many at this point
    
