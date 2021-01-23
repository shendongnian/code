    class ObjectA {
        public int A { get; set; }
        public ObjectA( int a ) {
            this.A = a;
        }
    }
    class ObjectB {
        public int B { get; set; }
        public ObjectB( int b ) {
            this.B = b;
        }
    }
    class ObjectC {
        public int C { get; set; }
        public ObjectC( int c ) {
            this.C = c;
        }
    }
    class DynamicOverloadResolution {
        ArrayList items;
        public DynamicOverloadResolution( ) {
            items = new ArrayList( ) { 
                new ObjectA( 1 ), new ObjectB( 2 ), new ObjectC( 3 )
            };
        }
        public void ProcessObjects( ) {
            foreach ( object o in items )
                processObject( o );
        }
        private void processObject( object o ) {
            Type t = typeof( DynamicOverloadResolution );
            IEnumerable<MethodInfo> processMethods = t.GetMethods( )
                .Where( m => m.Name == "process" );
            foreach(MethodInfo info in processMethods) {
                if ( info.GetParameters( ).First( ).ParameterType == o.GetType( ) )
                    info.Invoke( this, new object[ ] { o } );
            }
        }
        public void process( ObjectA a ) { Console.WriteLine( a.A ); }
        public void process( ObjectB b ) { Console.WriteLine( b.B ); }
        public void process( ObjectC c ) { Console.WriteLine( c.C ); }
    }
    class Program {
        static void Main( string[ ] args ) {
            var d = new DynamicOverloadResolution( );
            d.ProcessObjects( );
        }
    }
