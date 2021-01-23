    public interface IAnimal
    {
        string getType();
    }
    public interface IAnimalGroomer<T> where T:IAnimal
    {
        void groom(T t);
    }
    public class  Dog : IAnimal
    {
        public string getType() { return "DOG"; }
        public void clipNails() { }
    }
    public class DogGroomer : IAnimalGroomer<Dog>
    {
        public void groom(Dog dog)
        {
            dog.clipNails();
        }
    }
    public class Cat : IAnimal
    {
        public string getType() { return "CAT"; }
        public void clipNails() { }
    }
    public class CatGroomer : IAnimalGroomer<Cat>
    {
        public void groom(Cat cat)
        {
            cat.clipNails();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            // this is fine.
            IAnimalGroomer<Dog> doggroomer = new DogGroomer();
            // this is an invalid cast, but let's imagine we allow it! 
            IAnimalGroomer<IAnimal> animalgroomer = doggroomer;
            // compile time, groom parameter must be IAnimal, so the following is legal, as Cat is IAnimal
            // but at run time, the groom method the object has is groom(Dog dog) and we're passing a cat! we lost compile-time type-safety.
            animalgroomer.groom(new Cat());                                  
        }
    }
