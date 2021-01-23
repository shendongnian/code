    public class Animal
    {
        public string Color { get; private set; }
        public Animal(string color)
        {
            this.Color = color;
        }
        // These static methods **really** should be in a separate
        // factory class
        public static Bird CreateBird(string color, int wings)
        {
            return new Bird(color, wings);
        }
        public static Bird CreateBird(int wings, string color)
        {
            return new Bird(color, wings);
        }
        public static Dog CreateDog(string color, int paws)
        {
            return new Dog(color, paws);
        }
        public static Dog CreateDog(int paws, string color)
        {
            return new Dog(color, paws);
        }
    }
    public class Bird : Animal
    {
        public int Wings { get; private set; }
        public Bird(string color, int wings)
            : base(color)
        {
            this.Wings = wings;
        }
    }
    public class Dog : Animal
    {
        public int Paws { get; private set; }
        public Dog(string color, int paws)
            : base(color)
        {
            this.Paws = paws;
        }
    }
