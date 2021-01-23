    public class Animal
    {
    }
    
    public class Cow : Animal
    {
    }
    
    public class Animals
    {
        private List<Animal> _animals = new List<Animal>();
        
        public IEnumerable<T> GetAnimals<T>() where T : Animal
        {
            return _animals.Select(a => (T) a);
        }
    
        public void Add<T>(T animal) where T : Animal
        {
            _animals.Add(animal);
        }
    }
    
    
    public class Program
    {
        public static void Main()
        {
            Animals animals = new Animals();
            IEnumerable<Cow> cows = animals.GetAnimals<Cow>();
    
            foreach (var cow in cows)
            {
                // do something
            }
        }
    }
