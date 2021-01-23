    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    public class Customer
    {
        public string Time;
    	[FieldArrayLength(51)]
        public double[] L;
    	public string last;
    }
