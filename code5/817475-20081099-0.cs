    public static void Test<T>(T[] x, T[] y) where T : <SomeInterface>
    {
       List<T> list1 = new List<T>(x);
       List<T> list2 = new List<T>(y);
       IEnumerable<T> toBeAdded = list1.Where(x => list2.All(y => y.PropertyName != x.PropertyName));
        IEnumerable<T> toBeDeleted = list2.Where(a => list1.All(b => b.PropertyName)); != a.PropertyName));));
    
    }
 
