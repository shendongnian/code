    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog().Color("Red").Paw(4);
            Bird bird = new Bird().Color("Blue").Wing(1);
        }
    }
    public abstract class Animal
    {
        private string color = "";
        public Animal Color(string _color)
        {
            color = _color;
            return this;
        }
    }
    public abstract class ChainingAnimal<T> : Animal
        where T : Animal
    {
        public T Color(string _color)
        {
            return (T)base.Color(_color);
        }
    }
    public class Dog : ChainingAnimal<Dog>
    {
        private int pawNumber = 0;
        public Dog Paw(int _pawNumber)
        {
            pawNumber = _pawNumber;
            return this;
        }
    }
    public class Bird : ChainingAnimal<Bird>
    {
        private int wingNumber = 0;
        public Bird Wing(int _wingNumber)
        {
            wingNumber = _wingNumber;
            return this;
        }
    }
