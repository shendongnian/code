    public delegate T MaxDelegate<T>(T a, T b);
    void Main()
    {
        Console.WriteLine(	MaxClass<int>.whatIsTheMax(2,3) );
        
        // Just as a class when using a generic method,You must tell the compiler
        // the type parameter
	    Console.WriteLine( MaxMethod<int>(2,3) );
        // Now the max delegate of type MaxDelegate will only accept a method that has
        //   int someMethod(int a, int b) .It has the benefit of compile time check
	    MaxDelegate<int>  m = MaxMethod<int>;
        
        // MaxDelegate<int> m2 = MaxMethod<float>; // compile time check and error
	 
	    m(2,3);
	   //m(2.0,3.0);  //compile time check and error
    }
    public static T MaxMethod<T>(T a, T b) where T : IComparable<T>
    {
	   T retval = a;
	   if(a.CompareTo(b) < 0)
		 retval = b;
	   return retval;
    }
    public class MaxClass<T> where T : IComparable<T>
    {
	    public static  T whatIsTheMax(T a, T b)
	   {
	       T retval = a;
	     	if ( a.CompareTo(b) < 0)
		    	retval = b;
	 	    return retval;
	    }
    }
