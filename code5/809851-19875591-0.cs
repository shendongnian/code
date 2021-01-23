    public class Test
    {
    	public static void Main()
    	{
    		TInt X = 3;
    		Console.WriteLine(X);
    	}
    }
    class TInt
    {
        public TInt(int d) { _intvalue = d; }
        public TInt() { }
     
        int _intvalue;
     
        public static implicit operator TInt(int d)
        {
            return new TInt(d);
        }
    }
