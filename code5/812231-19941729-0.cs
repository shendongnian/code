    void Main()
    {
        Foo( "hello", "world", 123, false );
    }
    
    private static void Foo( string bar, string baz, int abc, bool xyz )
    {
        Evaluate( new { bar, baz, abc, xyz } );
    }
    
    private static void Evaluate( object o )
    {
        var properties = System.ComponentModel.TypeDescriptor.GetProperties( o );
        foreach( System.ComponentModel.PropertyDescriptor propertyDescriptor in properties )
        {
            var value = propertyDescriptor.GetValue( o );
            Console.WriteLine( "Name: {0}, Value: {1}", propertyDescriptor.Name, value );
        }
    }
