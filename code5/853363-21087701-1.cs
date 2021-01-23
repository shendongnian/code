	public struct City
	{
	    public string cityName { get; set; }
	    public float cityTemp { get; set; }
	    public override string ToString()
        {
            return String.Format("City: {0} is currently: {1}oC", cityName, cityTemp);
        }
	}
