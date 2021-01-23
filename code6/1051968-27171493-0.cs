    public class MainClass
    {
    	private Stack<Coordinates> _coordinateHistory;
    
    	public MainClass()
    	{
    		_coordinateHistory = new Stack<Coordinates>();
    	}
    
    	public void AddCoordinates(double x, double y)
    	{
    		_coordinateHistory.Push
    		(
    			new Coordinates(x, y);
    		)
    	}
    	
    	public Coordinates GetNextCoordinates()
    	{
    		return _coordinateHistory.Pop();
    	}
    	
    	public double CalculateDistance(Coordinates c1, Coordinates c2)
    	{
    		//Do your distance calculations here and return the result;
    		return null;
    	}
    }
    
    public class Coordinates
    {
    	private double _x;
    	public double X
    	{
    		get { return _x;  }
    	}
    	
    	private double _y;
    	public double Y
    	{
    		get { return _y;  }
    	}
    	
    	private DateTime _time;
    	public DateTime Time
    	{
    		get { return _time; }
    	}
    
    	public Coordinates(double x, double y)
    	{
    		_x = x;
    		_y = y;
    		_time = DateTime.Now;
    	}
    }
