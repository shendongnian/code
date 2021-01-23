    public class Service: IService
    {	
    	public Service(string name)
    	{
    		_name = name;
    	}
    	
    	public void Greet()
    	{
    		Console.WriteLine("Greetings from " + this.GetType().FullName + ". Assigned name is " + _name);
    	}
    	private string _name;
    }
