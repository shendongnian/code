    public class Pet {}
    public class Dog : Pet {}
    public class Cat : Pet {}
    
    static void Main(string[] args)
    {
        var list = new List<Pet>(); //  base type items
    
        list.Add(new Dog());
        list.Add(new Cat());
    }
