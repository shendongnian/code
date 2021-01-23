    public interface Animal
    {
         public string name {get;set;}
         public void speak();
    }
    public class Dog : Animal
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
    public class Cat : Animal
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
        Dictionary<string, Animal> myAnimals = new Dictionary<string, Animal>();
    
        Program(){
            myAnimals.Add("Maggie", new Dog("Maggie"));
            myAnimals["Maggie"].speak();
    
            myAnimals.Add("Whiskers", new Cat("Whiskers"));
            myAnimals["Whiskers"].speak();
    
            animalClinic clinic = new animalClinic();
            clinic.cureAnimal(myAnimals["Whiskers"]);
        }
    
        static void Main()
        {
            new Program();
        }
    }
    public class animalClinic()
    {
        public void cureAnimal(Dog animal)
        { 
             Console.WriteLine("We heal fine dogs!"); .
        }
        public void cureAnimal(Cat animal)
        { 
             Console.WriteLine("Eww a cat!")
        }
    }
