    interface IFactory {
        XElement ToXElement( object value );
    }
    class Factory<T> : IFactory {
        public XElement ToXElement( object value ) { return XElementSerialiser.ToXElement<T>( value ); }
    }
    public override Task WriteToStreamAsync( Type type, object value, 
                                        Stream writeStream, HttpContent content, 
                                        TransportContext transportContext, System.Threading.CancellationToken cancellationToken) {
        var factory = Activator.CreateInstance( typeof( Factory<> ).MakeGenericType( type ) ) as IFactory;
        return factory.ToXElement( value );
    }
