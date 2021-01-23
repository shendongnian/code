    public interface IAnimalCollection<out TAnimal> where TAnimal : IAnimal
    {
        TAnimal GetAnimal(int i);
        //int AddAnimal(TAnimal animal); //Can't have methods that take in the type when using "out"
    }
    class Program
    {
        static void Main(string[] args)
        {
            IAnimalCollection<IAnimal> animalCollection = GetDogCollection();
            //animalCollection.AddAnimal(new Cat()); //Would get a compiler error because this method no longer exists.
        }
        private static IAnimalCollection<IAnimal> GetDogCollection()
        {
            return new DogCollection();
        }
    }
