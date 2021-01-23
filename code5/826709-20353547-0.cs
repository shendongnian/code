    public Func<T> GetObjectCreator<T>( Type type )
    {
        // I'd probably add additional checks here to see that the
        // conversion to T is actually possible.
        var ctor = type.GetConstructor( Type.EmptyTypes );
        if( ctor == null ) throw new ArgumentException( "type", "Public parameterless constructor not found." )
        return () => (T) ctor.Invoke( null );
    }
