    public class Animal
    {
    }
    
    public interface IAnimalNoises
    {
        void MakeNoise();
    }
    
    public class Dog : Animal, IAnimalNoises
    {
         IAnimalNoises.MakeNoise()
         {
             Bark();
         }
    
         public void Bark()
         {
         }
    }
    
    public class Cat : Animal, IAnimalNoises
    {
         IAnimalNoises.MakeNoise()
         {
             Meow();
         }
    
         public void Meow()
         {
         }
    }
    
    public class PatternIamLookingFor
    {
        public static void DoSomething(IAnimalNoises animal)
        {
            animal.MakeNoise();
        }
    }
    
    Animal cat = new Cat();
    Animal dog = new Dog();
    PatternIamLookingFor.DoSomething(cat); // -> Call Meow
    PatternIamLookingFor.DoSomething(dog); // -> Call Bark
    
    Cat cat2 = new Cat();
    cat2.MakeNoise(); //Compiler error as it is not visible unless cast as a IAnimalNoises
