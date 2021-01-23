    class Animal
    {
       public virtual void MakeNoise()
       {
          Console.WriteLine("Ring-ding-ding-ding-dingeringeding!");
       }
    }
    class Dog : Animal
    {
       public override void MakeNoise() // changing behavior inherited from base
       {
          Console.WriteLine("Bark!");
       }
    }
