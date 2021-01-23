    // boilerplate (paste into LINQPad)
    void Main()
    {
         int bar;
    	 MethodWithParameters(1, out bar);
    	 Console.WriteLine( bar );
    }
    
    void MethodWithParameters( int foo, out int bar ){
    	
    bar = 123;
    var parameters = MethodInfo.GetCurrentMethod().GetParameters();
    
    foreach( var p in parameters )
    {
        if( p.IsOut ) // the important part
        {
            Console.WriteLine( p.Name + " is an out parameter." );
        }
      }
    }
