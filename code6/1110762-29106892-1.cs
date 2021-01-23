    public class Animal
    {
    }
    public class Cow : Animal
    {
    }
    public class Animals
    {
        private Type _animalType;
        private List<Animal> _animals = new List<Animal>();
        public Animals(Type animalType)
        {
            _animalType = animalType;
        }
        public IEnumerable<T> GetAnimals<T>() where T : Animal
        {
            return _animals.OfType<T>();
        }
        public void Add(Animal animal)
        {
            if (! _animalType.IsAssignableFrom(animal.GetType()))
                throw new Exception("Expected a " + _animalType.Name + " but was passed a " + animal.GetType().Name);
            _animals.Add(animal);
        }
    }
    public class Program
    {
        public static void Main()
        {
            Animals animals = new Animals(typeof(Cow));
            animals.Add(new Cow());
            IEnumerable<Cow> cows = animals.GetAnimals<Cow>();
    
            foreach (var cow in cows)
            {
                // do something
            }
        }
    }
