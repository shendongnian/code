    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, IGroomer>();
            dict.Add("Dog", new DogGroomer());
            // use it 
            IAnimal fido = new Dog();
            IGroomer sample = dict["Dog"];
            sample.Groom(fido);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
    // actual implementation
    public class Dog : IAnimal { }
    public class DogGroomer : AnimalGroomer<Dog>
    {
        public override void Groom(Dog beast)
        {
            Console.WriteLine("Shave the beast");
        }
    }
    public interface IAnimal {
        
    }
    public interface IGroomer
    {
        void Groom(object it);
    }
    public abstract class AnimalGroomer<T> : IGroomer where T : class, IAnimal
    {
      public abstract void Groom(T beast);
      public void Groom(object it)
      {
          if (it is T)
          {
              this.Groom(it as T);
              return;
          }
          throw new ArgumentException("The argument is not a " + typeof(T).GetType().Name);
      }
    }
