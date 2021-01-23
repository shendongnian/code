    var a = new Person( ) { LastName = "lastn", Name = "name", Address = "addr", ETC = "etc" };
    var b = new PersonData( );
    var infoPerson = typeof( PersonData ).GetProperties( );
    foreach ( PropertyInfo pi in typeof( Person ).GetProperties( ) ) {
        object value = pi.GetValue( a, null );
        infoPerson.Single( p => p.Name == pi.Name )
            .SetValue( b, value, null );
    }
