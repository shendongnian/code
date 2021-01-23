    public class SortStringLength : IComparer
        {
            public int Compare(Object s1, Object s2)
            {
                if (s1.ToString().Length == s2.ToString().Length)
                    return String.CompareOrdinal(s1.ToString(), s2.ToString());
                if (s1.ToString().Length > s2.ToString().Length)
                    return 1;
                return -1;
            }
        }
