    class Animal : object
    {
      public virtual void M()
      {
      }
    }
    class Mammal : Animal
    {
      public override void M()
      {
      }
    }
    class Giraffe : Mammal
    {
    }
    static class Test
    {
      internal static void Run()
      {
        var mi = typeof(Giraffe).GetMethod("M");
        Console.WriteLine(mi.ReflectedType);                     // Giraffe
        Console.WriteLine(mi.DeclaringType);                     // Mammal
        Console.WriteLine(mi.GetBaseDefinition().DeclaringType); // Animal
      }
    }
