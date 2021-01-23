    public class Mammal
    {
    }
    public class Cat: Mammal
    {
    }
    public class Dog: Mammal
    {
    }
    ...
    List<Cat> cats = new List<Cat>();
    List<Mammal> mammals = cats; // Imagine this compiles.
    mammals.Add(new Dog()); // We just added a dog to the list of cats!
    
