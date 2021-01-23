    [OperationContract]
    public void GetLargeComplexData();
    
    public GetLargeComplexData()
    {
       // deserialize last cached data from db or file
       ...
       
       // Verify the deserialized cache is not invalid
       ...
       
       // if cache is invalid rebuild
       ...
    
       //return cached data
       ...
    }
