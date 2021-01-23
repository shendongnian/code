    void Main()
    {
    	var clinic = new AnimalClinic();
    
        clinic.AddGroomer(new DogGroomer());
        clinic.AddGroomer(new CatGroomer());
    
        clinic.Groom(new Cat()); //Purrrr
        clinic.Groom(new Dog()); //Rooof!
    }
    
    public interface IAnimal {}
    
    public class Dog : IAnimal
    {    
        public string Growl => "Rooof!";        
    }
    
    public class Cat : IAnimal
    {
        public string Purr => "Purrrr";        
    }
    
    public interface IGroomer
    {
        void Groom(IAnimal animal);
    }
    
    public interface IGroomer<T> : IGroomer where T : IAnimal
    {
    	void Groom(T animal);
    }
    
    // Base class is not necessary, 
    // but hides the implementation details.
    public abstract class Groomer<T> : IGroomer<T> where T : IAnimal
    {
    	void IGroomer.Groom(IAnimal animal) => Groom((T)animal);
    	
    	public abstract void Groom(T animal);
    }
    
    public class DogGroomer : Groomer<Dog>    
    {
    	public override void Groom(Dog dog) => Console.WriteLine(dog.Growl);		
    }
    
    public class CatGroomer : Groomer<Cat>
    {     
    	public override void Groom(Cat cat) => Console.WriteLine(cat.Purr);
    }
    
    public class AnimalClinic
    {
        public Dictionary<Type, IGroomer> _groomers = new Dictionary<Type, IGroomer>();
    
        public void AddGroomer<T>(IGroomer<T> groomer) where T : class, IAnimal
        {
            _groomers.Add(typeof(T), groomer);
        }
    
        public void Groom<TAnimal>(TAnimal animal) where TAnimal : IAnimal
        {
            _groomers[typeof(TAnimal)].Groom(animal);
        }
    }
