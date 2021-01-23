    class Zwakmonster : IMonster
    {
        private string mijnNaam;
        private string mijnKleur;
        private int lives = 10;
    
        public string Naam
        {
            get { return mijnNaam; }
            set { mijnNaam = value; }
        }
    
        public string Kleur
        {
            get { return mijnKleur; }
            set { mijnKleur = value; }
        }
    
        public int Levens
        {
            get { return lives; }
        }
    
        public void Hit()
        {
            lives = lives - 1;
        }
    }
