    class FirstElementComparer : IEqualityComparer<string[]>
    {
        //TODO error checking
        public bool Equals(string[] a, string[] b)
        {       
            return a[0].Equals(b[0]);
        }
    
        public Int32 GetHashCode(string[] obj)
        {
            return obj[0].GetHashCode();
        }
    }
