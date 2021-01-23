    class Animal
    {
        public virtual void MakeSound() { Console.WriteLine("Animal called"); } 
    }
    
    class Dog : Animal
    {
        // Note: You can not use override and new in the same class, on 
        // the same method, with the same parameters.  This is just to 
        // show when "new" takes effect, and when "override" takes effect.
        public override void MakeSound() 
        { 
            Console.WriteLine("Animal's MakeSound called for dog"); 
        } 
        
        public new void MakeSound()
        {
            Console.WriteLine("Dog's MakeSound called"); 
        }
    }
    
    public static class Program
    {
        public static void Main(string[] args)
        {
            Dog dogAsDog = new Dog();
            Animal dogAsAnimal = dogAsDog;
    
            // prints "Dog's MakeSound called"
            dogAsDog.MakeSound();
    
            // prints "Animal's MakeSound called for dog"
            dogAsAnimal.MakeSound();
        }
    }
