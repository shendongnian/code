    public class FirstLetterComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
               return false; 
            //ignoring case
            return String.Compare(x[1],y[1],0) == 0;
        }
        public int GetHashCode(string str)
        {
            return str.GetHashCode();
        }
    }
    makes.Distinct(new FirstLetterComparer());
