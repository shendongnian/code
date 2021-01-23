    // no instance needed
    var propInfos = typeof( Foo ).GetProperties();
    foreach( PropertyInfo prop in propInfos )
    {
        // instance needed
        var instance = new Foo();
        Console.WriteLine( prop.Name + " := " + prop.GetValue( instance ) );
    }
