    void Main()
    {
        ObservableCollection<MyClass> first = new ObservableCollection<MyClass> { "1", "2", "3", "4", "5", "6", "k" };
        
        ISet<IMyInterface> second = new HashSet<IMyInterface>(new MyClass2[] { 2, 3, 5 }, new MyEqualityComparer());
        
        first.CrossRemove(second);
            
        Console.WriteLine(string.Join(", ", first.Select(x => x.MyProperty)));
        // 1, 4, 6, k
    }
    public interface IMyInterface
    {
        string MyProperty { get; set; }
    }
    public class MyEqualityComparer : IEqualityComparer<IMyInterface>
    {
        public bool Equals(IMyInterface a, IMyInterface b)
        {
            return a.MyProperty == b.MyProperty;
        }
        public int GetHashCode(IMyInterface obj)
        {
            return obj.MyProperty.GetHashCode();
        }
    }
    public static class Extensions
    {
        public static void CrossRemove<TFirst, TSecond>(this ObservableCollection<TFirst> collection, ISet<TSecond> set) where TFirst : TSecond
        {
            foreach (var item in collection.Where(item => set.Contains(item)).ToList())
                collection.Remove(item);
        }
    }
    public class MyClass : IMyInterface
    {
        public string MyProperty { get; set; }
        public static implicit operator MyClass(string s)
        {
            return new MyClass { MyProperty = s };
        }
    }
    public class MyClass2 : IMyInterface
    {
        public string MyProperty { get; set; }
        public static implicit operator MyClass2(int i)
        {
            return new MyClass2 { MyProperty = i.ToString() };
        }
    }
