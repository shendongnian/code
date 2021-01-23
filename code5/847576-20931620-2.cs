    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Animals
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<IAnimal> animals = new List<IAnimal>();
                animals.Add(new Dog());
                animals.Add(new Cat());
    
                foreach(Animal animal in animals)
                {
                    animal.PrintWhoAreYou();
                }
    
                Console.ReadKey();
            }
        }
    
        interface IAnimal
        {
            void PrintWhoAreYou();
        }
    
        abstract class Animal : IAnimal
        {
            public abstract void PrintWhoAreYou();
    
            private bool feeded = false;
    
            public void Feed()
            {
                feeded = true;
            }
    
        }
    
        class Dog : Animal
        {
            public override void PrintWhoAreYou()
            {
                Console.WriteLine("I am a dog!");
            }
        }
        class Cat : Animal
        {
            public override void PrintWhoAreYou()
            {
                Console.WriteLine("I am a cat!");
            }
        }
    }
