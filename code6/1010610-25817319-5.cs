    class Program
    {
        static void Main(string[] args)
        {
            IAnimalCollection<IAnimal> animalCollection = GetDogCollection();
            //animalCollection.AddAnimal(new Cat()); //Would get a compiler error if we tried to add a cat to the collection
        }
        private static IAnimalCollection<Dog> GetDogCollection()
        {
            return new DogCollection();
        }
    }
