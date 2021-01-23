    public class CustomSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            var chars = "YNSD".ToCharArray().ToList();
            if (chars.IndexOf((char)x) < chars.IndexOf((char)y))
                return -1;
            return chars.IndexOf((char)x) > chars.IndexOf((char)y) ? 1 : 0; 
        }
    }
