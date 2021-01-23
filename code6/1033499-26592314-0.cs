    public class Square
    {
        public static int CalculateSquare( int value )
        { return value * value; }
    }
    public class DynamicMethodExample
    {
        private delegate int SquareDelegate( int value );
        internal void CreateDynamicMethod()
        {
            MethodInfo getSquare = typeof( Square ).GetMethod( "CalculateSquare" );
            DynamicMethod calculateSquare = new DynamicMethod( "CalculateSquare",
                typeof( int ), new Type[] { typeof( int ) } );
            ILGenerator il = calculateSquare.GetILGenerator();
            // Load the first argument, which is a integer, onto the stack.
            il.Emit( OpCodes.Ldarg_0 );
            // Call the overload of CalculateSquare that returns the square of number
            il.Emit( OpCodes.Call, getSquare );
            il.Emit( OpCodes.Ret );
            SquareDelegate hi =
            ( SquareDelegate )calculateSquare.CreateDelegate( typeof( SquareDelegate ) );
            Console.WriteLine( "\r\nUse the delegate to execute the dynamic method:" );
            int retval = hi( 42 );
            Console.WriteLine( "Calculate square returned " + retval );
        }
    }
