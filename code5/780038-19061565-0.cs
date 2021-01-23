    public IEnumerable<object[]> GetQueryResults2()
    {
        var odClient = new ODataClient(UrlBase);
        var odResponse = odClient.FindEntries(CommandText);
        var responseRows = from row in odResponse
                            select new object[] 
                            { 
                                from field in row
                                join outputfield in OutputFields on field.Key equals outputfield.Key
                                select field.Value 
                            };
        return responseRows;
    }
