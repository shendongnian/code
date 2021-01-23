    class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if ((x == null) && (y == null))
            {
                return 0;
            }
            
            if (x == null)
            {
                return 1;
            }
            
            if (y == null)
            {
                return -1;
            }
            
            var l = Math.Min(x.Length, y.Length);
            for (var i = 0; i < l; i++)
            {
                var c = x[i];
                var d = y[i];
                if (c != d)
                {
                    if (char.ToLowerInvariant(c) == char.ToLowerInvariant(d))
                    {
                        return StringComparer.Ordinal.Compare(new string(c, 1), new string(d, 1));
                    }
                    else
                    {
                        return StringComparer.OrdinalIgnoreCase.Compare(new string(c, 1), new string(d, 1));
                    }
                }
            }
            
            return x.Length == y.Length ? 0 : x.Length > y.Length ? 1 : -1;
        }
    }
