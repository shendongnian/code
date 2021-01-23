    List<Class1> list1 = new List<Class1>();
    list1.Add(new Class1());
    List<Class2> list2 = new List<Class2>();
    list2.Add(new Class2());
    var unionList =  list1.Cast<object>()
        .Union(list2.Cast<object>(), new DynamicComparer())
        .ToList();
    internal class DynamicComparer : IEqualityComparer<object>
    {
        public new bool Equals(object x, object y)
        {
            dynamic dx = x;
            dynamic dy = y;
            return dx.Guid == dy.Guid;
        }
        public int GetHashCode(object obj)
        {
            dynamic dobj = obj;
            return dobj.Guid.GetHashCode();
        }
    }
    internal class Class1
    {
        public Guid Guid { get; set; }
    }
    internal class Class2
    {
        public Guid Guid { get; set; }
    }
