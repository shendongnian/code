    void Main()
    {
    	var clinic = new AnimalClinic();
    
        clinic.AddGroomer(new DogGroomer());
        clinic.AddGroomer(new CatGroomer());
    
        clinic.Groom(new Cat()); //Purrr
        clinic.Groom(new Dog()); //Rooof!
    }
    
    public interface IAnimal
    {
        string GroomSound { get; }
    }
    
    public class Dog : IAnimal
    {
        public string GroomSound => "Woof";        
        public string AngrySound => "Rooof!";        
    }
    
    public class Cat : IAnimal
    {
        public string GroomSound => "Purrr";        
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
    // but hides the implementation details
    // such that the inheritor does not need 
    // to consider IAnimal at all.
    public abstract class Groomer<T> : IGroomer<T> where T : IAnimal
    {
    	void IGroomer.Groom(IAnimal animal) => Groom((T)animal);
    	
    	public abstract void Groom(T animal);
    }
    
    public class DogGroomer : Groomer<Dog>    
    {
    	public override void Groom(Dog animal) => Console.WriteLine(animal.AngrySound);		
    }
    
    public class CatGroomer : Groomer<Cat>
    {     
    	public override void Groom(Cat cat) => Console.WriteLine(cat.GroomSound);
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
