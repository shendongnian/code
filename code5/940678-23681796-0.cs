    public override Task WriteToStreamAsync<T>(T value, 
                                            Stream writeStream, HttpContent content, 
                                            TransportContext transportContext, System.Threading.CancellationToken cancellationToken)
    {
        XElement xmloutput = XElementSerialiser.ToXElement<T>(value);
