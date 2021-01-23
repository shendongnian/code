        //Contains a collection of reservations and provides methods to get a 
        //reservation, get all reservations and set a new reservation
        Public class Reservations
        {
        	private List<Reservation> _reservations;  //Collection of reservations
        	
        	public Reservations()
        	{
        		//Initialize properties
        		this._reservations = new List<Reservation>();
        	}
        	
        	//Returns all reservations
        	public List<Reservation> GetAllReserved()
        	{
        		//If you are able to use linq, then use the following line
        		//return this._reservations.Where(res => res.IsReserved() = true).ToList();
        		
        		//Otherwise use this
        		List<Reservation> reserved = new List<Reservation>();
        		foreach (var res in this._reservations)
        		{
        			if (res.IsReserved())
        				reserved.Add(res);
        		}
        		
        		return reserved;
        	}
        	
        	//Returns all reservations on a given date
        	public List<Reservation> GetReservedOnDate(DateTime reservedOn)
        	{
        		//If you are able to use linq, then use the following line
        		//return this._reservations.Where(res => res.GetReservedOn() == reservedOn && res.IsReserved() = true).ToList();
        		
        		//Otherwise use this
        		List<Reservation> reserved = new List<Reservation>();
        		foreach (var res in this._reservations)
        		{
        			if (res.GetReservedOn.Date == reservedOn.Date && res.IsReserved())
        				reserved.Add(res);
        		}
        		
        		return reserved;
        	}
        	
        	//Sets a reservation on a given date. Returns true if one is created, returns false if one can not.
        	public bool SetReservation(DateTime reserveOn)
        	{
        		//Check to see if the date to reserve is already booked
        		//If you are able to use linq, then use the following line
        		if (_reservations.SingleOrDefault(res => res.GetReservedOn.Date == reservedOn.Date && 
        			res.GetReservedOn().Hour == reserveOn.Hour && 
        			res.IsReserved()) != null)
        		{
        			return false;
        		}
        			
        		//It has made it this far so no reservation exists at that time on that date, create a reservation
        		this._reservations.Add(new Reservation(reserveOn));
        		
        		return true;
        	}
        }
        
        //Contains the properties of a reservation. The reservation is ignorant of the hours as this provides
        //flexibility in the reservations collection handling class.
        public class Reservation
        {
        	private DateTime _reserveOn;	//Date to reserve
        	private bool _isReserved;		//Whether it is reserved
        	
        	//Overloaded constructor takes 1 parameter
        	public Reservation(DateTime reserveOn)
        	{
        		//Initialize properties with assigned parameters
        		this._reserveOn = reserveOn;  
        		this._isReserved = true;
        	}
        	
        	//Overloaded constructor takes 2 parameters
        	public Reservation(DateTime reserveOn, bool isReserved)
        		: this(reservedOn) //Calls the base constructor and passes 
        		                               //in the reserved on parameter
        	{
        		//Initialize properties with assigned parameters 
        		this._isReserved = true;
        	}
        	
        	//Returns the date the reservation is on
        	public GetReservedOn()
        	{
        		return this._reservedOn;
        	}
        	
        	//Sets the reservation
        	public void SetReservedOn(DateTime reserveOn)
        	{
        		this._reservedOn = reserveOn;
        	}
        	
        	//Returns whether the date time has been reserved
        	public bool GetIsReserved()
        	{
        		return this._isReserved;
        	}
        	
        	//Set the reservation as reserved
        	public void SetIsReserved(bool isReserved)
        	{
        		this._isReserved = isReserved;
        	}
        }
