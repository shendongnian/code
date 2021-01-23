    class CustomComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == y)
                return 0;
            else if (x == "Description B")
                return -1;
            else
                return (x.CompareTo(y));
        }
    }
