    class Animal
    {
       public virtual void MakeNoise()
       {
          Console.WriteLine("...");
       }
    }
    class Dog : Animal
    {
       public override void MakeNoise()
       {
          Console.WriteLine("Bark!");
       }
    }
