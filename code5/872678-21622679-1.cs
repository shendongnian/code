        class Base58Comparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (object.ReferenceEquals(x, y))
                    return 0;
                if (object.ReferenceEquals(x, null))
                    return -1;
                if (object.ReferenceEquals(y, null))
                    return 1;
                int minLen = Math.Min(x.Length, y.Length);
                for (int i = 0; i < minLen; i++)
                {
                    // comparison based on ASCII value
                    int comp = x[i].CompareTo(y[i]); 
                    if (comp != 0)
                        return comp;
                }
                return x.Length - y.Length;
            }
        }
