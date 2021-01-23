    enum TypeOfSensor 
    {
    	[Description("Heat sensor")]
    	HeatSensor,
    	[Description("Pressure sensor")]
    	PressureSensor
    }
    
    private static string ToDescription(this Enum value)
    {
    	var fi = value.GetType().GetField(value.ToString());
    
    	var attributes =
    		(DescriptionAttribute[])fi.GetCustomAttributes(
    		typeof(DescriptionAttribute),
    		false);
    
    	return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
    
    
    
    public IEnumerable<Sensor> Select(TypeOfSensor typeOfSensor)
    {
    	using (ISession session = NHibernateHelper.OpenSession())
    	{
    	  var sensorType = typeOfSensor.ToDescription();
    	  return session.Query<Sensor>()
    		  .Where(c =>c.TypeOfSensor == sensorType );
    	}
    }
