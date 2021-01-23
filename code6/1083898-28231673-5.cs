    class DomainComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if(x==y) return 0;
            string[] _x = x.Split('.');
            string[] _y = y.Split('.');
            return Compare(_x, _y, 0);
        }
        private int Compare(string[] x, string[] y, int depth)
        {
            if (x.Length - depth - 1 >= 0 && y.Length - depth -1 < 0)
            {
                return +1;
            }
            if (y.Length - depth - 1 >= 0 && x.Length - depth -1 < 0)
            {
                return -1;
            }
            if (x[x.Length-depth-1].CompareTo(y[y.Length - depth-1]) == 0)
            {
                return Compare(x, y, depth + 1);
            }
            else
            {
                return x[x.Length-depth-1].CompareTo(y[y.Length - depth-1]);
            }
        }
    }
