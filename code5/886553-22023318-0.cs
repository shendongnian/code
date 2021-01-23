    public class Car
    {
    	//update aa, n, and A to reflect what they represent.
    	//I'm guessing that n represents "name" and "aa" represents "speed"
    	//Unless you need inheritance, you can use private instead of protected
    	private double _speed;
    	private string _name;
    
    	//I'm guessing "A" represents "Speed".
    	public double Speed
    	{
    		get { return _speed; }
    		set { _speed = value; }
    	}
    	//This was in your base class, but you don't need it if
    	// "Speed" (what was "A") will work up here
    	//public virtual double Speed()
    	//{
    	//	return 0;
    	//}
    
    	public string Name
    	{
    		get { return _name; }
    		set { _name = value; }
    	}
    
    	//parameters should reflect what they represent, as well
    	public Car(double speed, string name)
    	{
    		this._speed = speed;
    		this._name = name;
    	}
    
    
    	public override string ToString()
    	{
    		//return Name;
    		//If you want to show the name and the speed in the listbox
    		//you could use the following:
    		return string.Format("{0} is going {1}", Name, Speed);
    	}
    }
