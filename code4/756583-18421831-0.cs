    public interface IZooAnimal
    {
        string Id { get; set; }
    }
    public class Lion : IZooAnimal
    {
        public string Id { get; set; }
    }
    public class Zebra : IZooAnimal
    {
        public string Id { get; set; }
    }
    public interface ICage
    {
        IEnumerable<IZooAnimal> WeaklyTypedAnimals { get; }
    }
    public class Cage<T> : ICage where T : IZooAnimal
    {
        public IList<T> Animals { get; set; }
        public IEnumerable<IZooAnimal> WeaklyTypedAnimals
        {
            get { return (IEnumerable<IZooAnimal>) Animals; }
        }
    }
    public class Zoo
    {
        public IList<ICage> ZooCages { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var lion = new Lion();
            var lionCage = new Cage<Lion>();
            lionCage.Animals = new List<Lion>();
            lionCage.Animals.Add(lion);
            var zebra = new Zebra();
            var zebraCage = new Cage<Zebra>();
            zebraCage.Animals = new List<Zebra>();
            zebraCage.Animals.Add(zebra);
            var zoo = new Zoo();
            zoo.ZooCages = new List<ICage>();
            zoo.ZooCages.Add(lionCage);
        }
    }
