    public interface IAnimal
    {
       string Name { get; }
    }
      [KnownType(typeof(Cat))]
      [KnownType(typeof(Dog))]
    public class Animal: IAnimal
    {
      string Name { get; }
    }
    public class Cat : Animal
    {
      string Name { get; set; }
    }
    public class Dog: Animal
    {
      string Name { get; set; }
    }
