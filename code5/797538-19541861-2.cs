    namespace GenericsTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<IAnimalStrategy<IAnimal>> strategies = new List<IAnimalStrategy<IAnimal>>();
                strategies.Add(new BarkStrategy());
            }
        }
        interface IAnimal { }
        interface IAnimalStrategy<out T> where T : IAnimal { }
        class Dog : IAnimal { }
        class BarkStrategy : IAnimalStrategy<Dog> { }
    }
