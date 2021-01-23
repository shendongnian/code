    static bool DoSomething()
    {
         //This is where the debugger now breaks execution
         throw new Exception( "Something went wrong!" );
         return true;
    }
        
    [DebuggerStepThrough]
    static public void DoSomeStep()
    {
        try
        {                
            DoSomething();
        }
        catch( Exception exception )
        {
            Console.WriteLine( exception.Message );
            if( Debugger.IsAttached == true )
            {
                //the debugger no longer breaks here
                throw;
            }
        }
    }
    static void Main( string[] args )
    {          
        for( int i = 0; i < 10; i++ )
        {
            DoSomeStep();
        }
    }
