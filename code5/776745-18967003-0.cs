    class Gadget
    {
      public IList<int> FizzBuzz( int length , int startValue )
      {
        if ( length < 0 ) throw new ArgumentOutOfRangeException("length") ;
        int[] list = new int[length];
        for ( int i = 0 ; i < list.Length ; ++i )
        {
          list[i] = startValue++ ;
        }
        return list ;
      }
    }
    class Program
    {
      static void Main( string[] args )
      {
        object     x             = new Gadget() ;
        Type       t             = x.GetType() ;
        MethodInfo mi            = t.GetMethod("FizzBuzz") ;
        object     returnedValue = mi.Invoke( x , new object[]{ 10 , 101 } ) ;
        IList<int> returnedList  = (IList<int>) returnedValue ;
        string     msg           = returnedList.Select( n => n.ToString(CultureInfo.InvariantCulture)).Aggregate( (s,v) => string.Format("{0}...{1}" , s , v) ) ;
        Console.WriteLine(msg) ;
        return;
      }
    }
