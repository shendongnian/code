    public interface IAnimal
    {
         public string name {get;set;}
         public void speak();
    }
    public class Dog : IAnimal
    {
        public Dog (string n)
        {
            name = n;
        }
        public string name {get;set;}
        public void bark() 
        {
            Console.WriteLine("\"Woof Woof\" - " + name);
        }
        public void speak() { bark(); }
    }
    public class Cat : IAnimal
    {
        public Cat(string n)
        {
            name = n;
        }
        public string name {get;set;}
        public void meow() 
        {
            Console.WriteLine("\"Meow Meow\" - " + name);
        }
        public void speak() { meow(); }
    }
    class Program
    {
        static Dictionary<string, IAnimal> myAnimals = new Dictionary<string, IAnimal>();
    
        static void Main()
        {
            myAnimals.Add("Maggie", new Dog("Maggie"));
            myAnimals["Maggie"].speak();
    
            myAnimals.Add("Whiskers", new Cat("Whiskers"));
            myAnimals["Whiskers"].speak();
    
            animalClinic clinic = new animalClinic();
            clinic.cureAnimal(myAnimals["Whiskers"]);
        }
    }
    public class animalClinic()
    {
        public void cureAnimal(Dog animal)
        { 
             Console.WriteLine("We heal fine dogs!"); 
        }
        public void cureAnimal(Cat animal)
        { 
             Console.WriteLine("Eww a cat!");
        }
        public void cureAnimal(IAnimal animal)
        { 
             Console.WriteLine("I don't know what this is!");
        }
    }
