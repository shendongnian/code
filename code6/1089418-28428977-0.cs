    EditTime[] sourceRows;
    using (var sourceContext = CreateSourceContext())
    {
        sourceRows = ReadRows(sourceContext);
    }
    
    using (var destinationContext = CreateDestinationContext())
    {
        WriteRows(destinationContext, sourceRows);
    }
