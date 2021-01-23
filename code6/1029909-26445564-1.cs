    class Animal
    {
    }
    class Dog : Animal
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog ();
            dog = new Animal(); // Oops ! Not possible
        }
    }
