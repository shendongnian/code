     class ContenuComparer : IEqualityComparer<Contenu>
    {
        public bool Equals(Contenu x, Contenu y)
        {
            if (x.ContenuID == y.ContenuID)
                return true;
            return false;
        }
        public int GetHashCode(Contenu obj)
        {
            return obj.ContenuID.GetHashCode();
        }
    }
