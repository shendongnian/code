    interface ICreature
    {
        void Speak();
    }
    
    class Animal : ICreature
    {
        public void Speak() { Console.WriteLine("Rawr"); }
    }
    
    class Duck:Animal
    {
        public void Speak() { Console.WriteLine("Quack"); }
    }
    
    class Human : Animal, ICreature
    {
        public void Speak() { Console.WriteLine("Hello"); }
    }
