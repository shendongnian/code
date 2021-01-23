     public void Compute( Func<int, int, int> function, int x, int y )
     {
         return function( x, y );
     }
 
     public int multiply( int x, int y )
     {
         return x*y;
     }
      ...
     Compute( multiply, 2, 3 );
