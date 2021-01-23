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
    
    //Coordinates object that contains the X, Y 
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
    	
    	private double _latitude;
    	public double Latitude
        {
            get { return _latitude;  }
    		set { _latitude = value; }
        }
    	
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
    	
    	public Coordinates() { }
    
        public Coordinates(double x, double y)
        {
            InitializeCoordinates(x, y, DateTime.Now);
        }
    	
    	public Coordinates(double x, double y, DateTime time)
    	{
    		InitializeCoordinates(x, y, time);
    	}
    	
    	private void InitializeCoordinates(double x, double y, DateTime time)
    	{
    		_x = x;
            _y = y;
            _time = time;
    	}
    }
