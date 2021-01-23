        int Legs();
    }
    public interface IAnimalFactory<T>
    {
        IAnimal CreateAnimal();
        T CreateSpecificAnimal();
    }
    public interface IDog:IAnimal 
    {
        void WagTail();
    }
    public interface ICat : IAnimal
    {
        void LandOnFeet();
    }
    public class Dog:IDog
    {
    //Implementation Excluded
    }
    public class Cat : ICat
    {
     //Implementation Excluded
    }
    public class DogFactory:IAnimalFactory<IDog>
    {
        public IAnimal CreateAnimal()
        {
            return (IAnimal)CreateSpecificAnimal();
        }
        public IDog CreateSpecificAnimal()
        {
            return new Dog();
        }
    }
    public class CatFactory : IAnimalFactory<ICat>
    {
        public IAnimal CreateAnimal()
        {
            return (IAnimal)CreateSpecificAnimal();
        }
        public ICat CreateSpecificAnimal()
        {
            return new Cat();
        }
    }
