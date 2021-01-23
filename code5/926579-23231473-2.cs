    public class Nested
    {
      public Nested Child
      {
          get;
          set;
      }
    }
    		
    public class NullCheck
    {
       public bool IsNull { get; private set; }
    
       // continues the chain
       public NullCheck ThenCheck( Func<object> test )
       {
           if( !IsNull )
           {
               // only evaluate if the last state was "not null"
    	       this.IsNull = test() == null;
           }
    
           return this;
       }
    
       // starts the chain (convenience method to avoid explicit instantiation)
       public static NullCheck Check( Func<object> test )
       {
           return new NullCheck { IsNull = test() == null };
       }
    }
    
    private void Main()
    {
       // test 1
       var nested = new Nested();
       var isNull =
           NullCheck.Check( () => nested )
               .ThenCheck( () => nested.Child )
               .ThenCheck( () => nested.Child.Child )
               .ThenCheck( () => nested.Child.Child.Child )
               .ThenCheck( () => nested.Child.Child.Child.Child );
    
       Console.WriteLine( isNull.IsNull ? "null" : "not null" );
    
       // test 2
       nested = new Nested { Child = new Nested() };
       isNull = NullCheck.Check( () => nested ).ThenCheck( () => nested.Child );
    
       Console.WriteLine( isNull.IsNull ? "null" : "not null" );
       
       // test 3
       nested = new Nested { Child = new Nested() };
       isNull = NullCheck.Check( () => nested ).ThenCheck( () => nested.Child ).ThenCheck( () => nested.Child.Child );
    
       Console.WriteLine( isNull.IsNull ? "null" : "not null" );
    }
