    public class Car
    {
    	public Car()
    	{
    		YearProperty = new CarProperty
    		{
    			Background = new SolidColorBrush(Colors.Transparent),
    			Foreground = new SolidColorBrush(Colors.Black),
    			FontWeight = FontWeights.Normal
    		};
    	}
    	public string Name { get; set; }
    	public string Make { get; set; }
    	public string Year { get; set; }
    	public CarProperty YearProperty { get; set; }
    }
