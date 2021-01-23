    class AnimalProcessor
    {
    	public void Process(Animal animal)
    	{
    		dynamic concreteAnimal = animal;
    
    		DoProcess(concreteAnimal);
    	}
    
    	private void DoProcess(Animal animal)
    	{
    		throw new NotImplementedException();
    	}
    
    	private void DoProcess(Cat cat)
    	{
    		System.Diagnostics.Debug.WriteLine("Do Cat thing");
    	}
    
    	private void DoProcess(Dog dog)
    	{
    		System.Diagnostics.Debug.WriteLine("Do Dog thing");
    	}
    }
