    public interface IZooAnimal
    {
        string Id { get; set; }
    }
    
    public interface ICage<out T> where T : IZooAnimal
    {
        IReadOnlyCollection<T> Animals { get; }
    }
    
    public class Cage<T> : ICage<T> where T: IZooAnimal
    {
        private readonly List<T> animals = new List<T>();
    
        public IReadOnlyCollection<T> Animals
        {
            get
            {
                return animals.AsReadOnly();
            }
        }
    
        public void CageAnimal(T animal)
        {
            animals.Add(animal);
        }
    }
    
    public class Lion : IZooAnimal
    {
        public string Id { get; set; }
    }
    
    public class Zebra : IZooAnimal
    {
        public string Id { get; set; }
    }
    
    public class Zoo
    {
        public IList<ICage<IZooAnimal>> Cages { get; set; }
    }
    
    internal class Program
    {
    
        private static void Main(string[] args)
        {
            var lion = new Lion();
            var zebra = new Zebra();
            var lionCage = new Cage<Lion>();
            lionCage.CageAnimal(lion);
    
            var zebraCage = new Cage<Zebra>();
            zebraCage.CageAnimal(zebra);
    
            var zoo = new Zoo();
            zoo.Cages.Add(lionCage);
            zoo.Cages.Add(zebraCage);
    
        }
    }
