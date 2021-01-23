    public interface IAnimal{
      string GetType();
    }
    
    public interface IAnimalGroomer{
      void Groom(IAnimal dog);
    }
    
    public class Dog : IAnimal
    {
        public string GetType()
        {
            return "DOG";
        }
    
        public void ClipNails()
        {
    
        }
    }
    
    public class DogGroomer : IAnimalGroomer
    {
        public void Groom(IAnimal dog)
        {
            if (dog is Dog)
            {
                (dog as Dog).ClipNails();
            }
            else {
                 // something you want handle.
            }
        }
    }
    
    
    
    
    public class Program
    {
        private List<IAnimalGroomer> groomers = new List<IAnimalGroomer>();
    
        public void doSomething()
        {
            groomers.Add(new DogGroomer());
        }
    }
