    public class SubstringComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return x.Substring(0, 6).CompareTo(y.Substring(0, 6));
            }
        }
