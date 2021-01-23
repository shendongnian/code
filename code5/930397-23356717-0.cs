    [OperationContract(Name="SaveSomeDataDefault")]
    public void SaveSomeData(SomeDataEntity[] someDataEntities) 
    {
        this.Invoke("SaveSomeData", new object[] { someDataEntities });
    }
    
    [OperationContract(Name="SaveSomeDataWithMode")]
    public void SaveSomeData(SomeDataEntity[] someDataEntities, string mode)
    {
        someDataLocator.SaveData(someDataEntities, mode);
    }
