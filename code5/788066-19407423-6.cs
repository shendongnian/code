    void Main()
    {
    	var clinic = new AnimalClinic();
    
    	clinic.Add(new CatGroomer());
        clinic.Add(new DogGroomer());
    	clinic.Add(new MeanDogGroomer());    
    
        clinic.Groom(new Cat()); //Purr
        clinic.Groom(new Dog()); //Woof , Grrr!
    }
    
    public interface IAnimal {}
    public interface IGroomer {}
    
    public class Dog : IAnimal
    {    
    	public string Woof => "Woof";
        public string Growl => "Grrr!";        
    }
    
    public class Cat : IAnimal
    {
        public string Purr => "Purr";        
    }
    
    public interface IGroomer<T> : IGroomer where T : IAnimal
    {
    	void Groom(T animal);
    }
    
    public class DogGroomer : IGroomer<Dog>    
    {
    	public void Groom(Dog dog) => Console.WriteLine(dog.Woof);		
    }
    
    public class MeanDogGroomer : IGroomer<Dog>    
    {
    	public void Groom(Dog dog) => Console.WriteLine(dog.Growl);		
    }
    
    public class CatGroomer : IGroomer<Cat>
    {     
    	public void Groom(Cat cat) => Console.WriteLine(cat.Purr);
    }
    
    public class AnimalClinic
    {
    	private TypedLookup<IGroomer> _groomers = new TypedLookup<IGroomer>();
    
    	public void Add<T>(IGroomer<T> groomer) where T : IAnimal 
          => _groomers.Add<T>(groomer);
    
        public void Groom<T>(T animal) where T : IAnimal 
          => _groomers.OfType<T, IGroomer<T>>().ToList().ForEach(g => g.Groom(animal));    
    }
    
    public class TypedLookup<T> : Dictionary<Type, IList<T>>
    {
    	public void Add<TType>(T item) 
    	{ 	
    		IList<T> list;
    		if(TryGetValue(typeof(TType), out list))
    			list.Add(item); 
    		else
    			this[typeof(TType)] = new List<T>{item};
    	}
    
    	public IEnumerable<TRet> OfType<TType, TRet>() => this[typeof(TType)].Cast<TRet>();
    	public TRet First<TType, TRet>() => this[typeof(TType)].Cast<TRet>().First();
    }
