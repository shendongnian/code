    var list = new List<IStoredObject>();
    
    list.Add(new Dog());
    
    list.Add(new Rose());
    
    //Retrieve the stored value casting as IAnimal which has Ianimal interface...
    list.Get<IAnimal>(); 
    
    public class Dog : IAnimal, IStoredObject
    {
    }
    
    public class Rose : IPlant, IStoredObject
    {
    }
