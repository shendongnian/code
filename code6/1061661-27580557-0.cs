    public interface ICar
    {
    	void Accelerate();
    }
    
    public interface IEngine
    {
    	void Accelerate();
    }
    
    public class Car: ICar
    {
    	private readonly IEngine _engine;
    	public Car(IEngine engine)		
    	{
    		_engine = engine;
    	}
    	
    	public void Accelerate()
    	{
    		_engine.Accelerate();
    	}
    }
    
    public class Engine: IEngine
    {    	
    	public Engine()		
    	{		
    	}
    	
    	public string Message {get; set;}
    	
    	public void Accelerate()
    	{
    		Console.WriteLine("Accelerating." + Message);
    	}
    }
