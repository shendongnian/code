    using System;
    using System.Collections.Generic;
    
    public interface IAnimalVisitor
    {
    	void Visit(Dog dog);
    	void Visit(Fox fox);
    }
    
    public class FeedingPersonnel : IAnimalVisitor
    {
    	public void Visit(Dog dog) 
    	{
    		Console.WriteLine("return dog food");
    	}
    
    	public void Visit(Fox fox)
    	{
    		Console.WriteLine("return fox food");
    	}
    }
    
    //public class Veterinarian : IAniamalVisitor { ... } (if you need it)
    interface IAnimal 
    {
    	void Accept( IAnimalVisitor visitor);
    	void MakeNoise();
    }
    
    public sealed class Dog : IAnimal {
    	public void Accept( IAnimalVisitor visitor) { visitor.Visit(this); }
        public void MakeNoise() { Console.WriteLine("Woof woof"); }
    }
    
    public sealed class Fox : IAnimal {
    	public void Accept( IAnimalVisitor visitor) { visitor.Visit(this); }
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
    		   animal.Accept(feeder);
    		}
    	}
    }
