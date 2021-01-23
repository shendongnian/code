    class Program {
        static void Main( string[ ] args ) {
            Printer instance = new Printer( );
            Type type = typeof( string );
            
            typeof( Printer ).GetMethod( "print" )
                .MakeGenericMethod( type )             // <-- Here
                .Invoke( instance, new object[ ] { "Hello World!" } );
        }
    }
    class Printer {
        public void Print<T>( T t ) {
            Console.WriteLine( t.ToString( ) );
        }
    }
