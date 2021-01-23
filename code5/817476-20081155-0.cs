    public static void Test<T>(T[] x, T[] y) where T : MyObjectType
    {
        List<T> list1 = new List<T>(x);
        List<T> list2 = new List<T>(y);
        IEnumerable<T> toBeAdded = list1.Where(x => list2.All(y => y.Property1  != x.Property1 ));
        IEnumerable<T> toBeDeleted = list2.Where(a => list1.All(b => b.Property1 )); != a.[How To Set Property Here?]));));
    }
