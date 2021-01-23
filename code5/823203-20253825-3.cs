    public Expression<Func<Example, IEnumerable<ExampleDCDTO>>> SelectDTO()
    {
        return v => db.ExampleUDCs.Where(vudc => vudc.ExampleID == v.ExampleID)
            .AsEnumerable()
            .Select(vudc => new ExampleDCDTO
            {
                ExampleID = vudc.ExampleID,
                UDCHeadingID = vudc.UDCHeadingID,
                UDCValue = vudc.UDCValue
            });
    }
