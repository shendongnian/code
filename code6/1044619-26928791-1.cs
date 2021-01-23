    public interface IAnimal
    {
    	string Name { get; set; }
    }
    
    public interface IDog : IAnimal
    {
    
    }
        
    public void QueryAnimalProperties<T>(out T animal)
    where T : IAnimal, new()
    {
    	animal = new T();
    	animal.Name = "Fred";    
    }    
    
    public class Dog : IDog
    {
    	public string Name { get; set; }
    }
    
    void Main()
    {
    	Dog dog;
    	QueryAnimalProperties(out dog);
    	Console.WriteLine(dog.Name);
    }
