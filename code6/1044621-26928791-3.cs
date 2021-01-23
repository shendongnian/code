    public Dog QueryDogProperties()
    {
    	Dog dog = new Dog();
    	dog .Name = "Fred";
    	return dog;
    }    
    void Main()
    {
    	Dog dog = QueryDogProperties(g);
    	Console.WriteLine(dog.Name);
    }
