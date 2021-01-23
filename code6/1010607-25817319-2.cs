    public interface IAnimal { }
    public class Dog : IAnimal { }
    public class Cat : IAnimal { }
    public interface IAnimalCollection<TAnimal> where TAnimal : IAnimal
    {
        TAnimal GetAnimal(int i);
        int AddAnimal(TAnimal animal);
    }
    public class DogCollection : IAnimalCollection<Dog>
    {
        private List<Dog> _dogs = new List<Dog>();
        public Dog GetAnimal(int i)
        {
            return _dogs[i];
        }
        public int AddAnimal(Dog animal)
        {
            _dogs.Add(animal);
            return _dogs.Count - 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IAnimalCollection<IAnimal> animalCollection = GetDogCollection();
            animalCollection.AddAnimal(new Cat()); //We just added a cat to a collection of dogs.
        }
        private static IAnimalCollection<IAnimal> GetDogCollection()
        {
            return new DogCollection();
        }
    }
