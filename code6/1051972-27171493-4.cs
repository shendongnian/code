    public class MainClass
    {
        private Stack<Coordinates> _coordinateHistory;  //Stores the coordinate history
    
    	//Base class that initializes the stack of coordinate history.
        public MainClass()
        {
            _coordinateHistory = new Stack<Coordinates>();
        }
    
    	//Used to create a new coordinate object and add it to the coordinate history stack.
        public void AddCoordinates(double x, double y)
        {
            _coordinateHistory.Push
            (
                new Coordinates(x, y);
            )
        }
    
    	//Gets the next coordinate in the history stack.
        public Coordinates GetNextCoordinates()
        {
            return _coordinateHistory.Pop();
        }
    
    	//Optional method to do all the calculations needed to get distance.
        public double CalculateDistance(Coordinates c1, Coordinates c2)
        {
            //Do your distance calculations here and return the result;
            return null;
        }
    }
    
    //Coordinates object that contains the X, Y, time stamp and optionally, latitude and longitude.
    public class Coordinates
    {
        private double _x;
        public double X
        {
            get { return _x;  }
    		set { _x = value; }
        }
    
        private double _y;
        public double Y
        {
            get { return _y;  }
    		set { _y = value; }
        }
    	
    	//Optional
    	private double _latitude;
    	public double Latitude
        {
            get { return _latitude;  }
    		set { _latitude = value; }
        }
    	
    	//Optional
    	private double _longitude;
    	public double Longitude
        {
            get { return _longitude;  }
    		set { _longitude = value; }
        }
        private DateTime _time;
        public DateTime Time
        {
            get { return _time;  }
            set { _time = value; }
        }
    	
    	//Base constructor
    	public Coordinates() { }
    
    	//Overloaded constructor that accepts the X and Y coordinates as parameters.
        public Coordinates(double x, double y)
        {
            InitializeCoordinates(x, y, DateTime.Now);
        }
    	
    	//Overloaded constructor that accepts the X and Y coordinates, and a date time object.
    	public Coordinates(double x, double y, DateTime time)
    	{
    		InitializeCoordinates(x, y, time);
    	}
    	
    	//Private method that initializes the variables of this coordinate object.  This is to reduce unnecessary replicated code.
    	private void InitializeCoordinates(double x, double y, DateTime time)
    	{
    		_x = x;
            _y = y;
            _time = time;
    	}
    }
