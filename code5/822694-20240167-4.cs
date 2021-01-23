    internal class Tricheur : Eleve, ITricheur
    {
        public Tricheur(string a, string b)
        {
        }
        void ITricheur.triche()
        {
            // If you remove this method, you'll get
            // always into the overriden method below.
        }
        public override void triche()
        {
        }
    }
