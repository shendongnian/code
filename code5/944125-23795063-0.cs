    class Program{
    	static void Main(string[] args)
    	{
    	    BiasCode b = BiasCode.MPP;
    	    var these = b.Values().ToList();
    		//...  these contains the actual values as the enum type
    	}
    }
    public static class EnumExtensions
    {
        public static IEnumerable<T> Values<T>(this T theEnum) where T : struct,IComparable, IFormattable, IConvertible
        {
            var enumValues = new List<T>();
    
            if ( !(theEnum is Enum))
                throw new ArgumentException("must me an enum");
    
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
