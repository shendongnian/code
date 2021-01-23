    class foo {
        public foo( ) {
            Console.WriteLine( "A" );
        }
        public foo( string x ) {
            Console.WriteLine( x );
            var c = this.GetType( ).GetConstructor( new Type[ ] { } );
            c.Invoke( new object[ ] { } );
        }
    }
    class Program {
        static void Main( string[ ] args ) {
            new foo( "www" );
        }
    }
