    using System;
    using System.Collections.Generic;
    
    public interface IAnimalVisitor
    {
    	void VisitDog(Dog dog);
    	void VisitFox(Fox fox);
    }
    
    public class FeedingPersonnel : IAnimalVisitor
    {
    	public void VisitDog(Dog dog) 
    	{
    		Console.WriteLine("return dog food");
    	}
    
    	public void VisitFox(Fox fox)
    	{
    		Console.WriteLine("return fox food");
    	}
    }
    
    //public class Veterinarian : IAniamalVisitor { ... } (if you need it)
    interface IAnimal 
    {
    	void Visit( IAnimalVisitor visitor);
    	void MakeNoise();
    }
    
    public sealed class Dog : IAnimal {
    	public void Visit( IAnimalVisitor visitor) { visitor.VisitDog(this); }
        public void MakeNoise() { Console.WriteLine("Woof woof"); }
    }
    
    public sealed class Fox : IAnimal {
    	public void Visit( IAnimalVisitor visitor) { visitor.VisitFox(this); }
        public void MakeNoise() { Console.WriteLine("What does the fox say?"); }
    }
    
    
    public class Test
    {
    	public static void Main()
    	{
    		var myList = new List<IAnimal> { new Dog(), new Fox() };
    		var feeder = new FeedingPersonnel();
     
    		foreach (var animal in myList)
    		{
    		   animal.Visit(feeder);
    		}
    	}
    }
