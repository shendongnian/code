    private static void Main(string[] args)
    {
        var dogs1 = new List<Dog>
        {
            new Dog{Name = "Sam", Color = "Fawn"},
            new Dog{Name = "Mary", Color = ""},
            new Dog{Name = "Bob", Color = ""}
        };
        var dogs2 = new List<Dog>
        {
            new Dog{Name = "Mary", Color = "Black"},
            new Dog{Name = "Bob", Color = "Yellow"}
        };
        var comparer = new Comparer();
        var common = dogs1.Intersect(dogs2, comparer).ToList();
        var res = dogs1.Except(common, comparer)
            
            .Union(dogs2.Except(common, comparer));
    }
    public class Dog : INameable
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
    public interface INameable
    {
        string Name { get; }
    }
    public class Comparer : IEqualityComparer<INameable>
    {
        public bool Equals(INameable x, INameable y)
        {
            return x.Name == y.Name;
        }
        public int GetHashCode(INameable obj)
        {
            return obj.Name.GetHashCode();
        }
    }
 
}
