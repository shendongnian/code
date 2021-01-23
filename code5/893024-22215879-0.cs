    public interface IDoesSound {
      void Sound();
    }
  
    public class Dog : IDoesSound {
      public void Sound() {
        Console.WriteLine("Dog goes Woof!");
      }
    }
    public class Cat : IDoesSound {
      public void Sound() {
        Console.WriteLine("Cat goes Mew!");
      }
    }
