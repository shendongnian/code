       class Comparer : IEqualityComparer<object[]>
            {
                public bool Equals(object[] x, object[] y)
                {
                    if (x.Length != y.Length)
                        return false;
        
                    for (int i = 0; i < x.Length; ++i)
                        if (!x[i].Equals(y[i]))
                            return false;
        
                        return true;
                    }
        
                    public int GetHashCode(object[] obj)
                    {
                        return string.Join("", obj).GetHashCode();
                    }
            }
       
         static void Main(string[] args)
            {
                var foo = new List<object[]>();
        
                foo.Add(new object[] { 1, "Something", true });
                foo.Add(new object[] { 1, "Some Other", false });
                foo.Add(new object[] { 2, "Something", false });
                foo.Add(new object[] { 2, "Something", false });
        
                var distinctList = foo.Distinct(new Comparer()).ToList();
    /*
    distinctList now contains
    1, "Something", true
    1, "Some Other", false
    2, "Something", false
    */
            }
