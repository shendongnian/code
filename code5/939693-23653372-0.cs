    class Dependency : IDependency
    {
      public Dependency(string userInput) { }
    }
    
    interface IDependencyFactory {
    	IDependency Create(string userInput);
    }
    
    class DependencyFactory: IDependencyFactory {
    	IDependency Create(string userInput) {
    		return new Dependency(userInput);
    	}
    }
    
    class Dependent {
    	public Dependent(IDependencyFactory factory) {
    		// guard clause omitted
    		_factory = factory
    	}
    	
    	private readonly IDependencyFactory _factory;
    
        void DoSomething() {
    		// Do not call the container, let it call you.
    		// So no container usage here.
    		//var container = ...
    
    		Console.Write("Hey, user. How are you feeling?");
    		var userInput = Console.ReadLine();
    
    		var dependency = _factory.Create(userInput);
    		// There you go!
        }
    }
