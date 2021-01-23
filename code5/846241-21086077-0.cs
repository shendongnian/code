    [TestMethod]
    public void derived_test()
    {
        using (ShimsContext.Create())
        {
            ShimFileCreationInformation fileCreationInformation = new ShimFileCreationInformation();
                    
            ShimFileCreationInformation.AllInstances.UrlGet = (instance) => "ThisisTest";
    
            SomeFunction(fileCreationInformation);
        }
    }
    public void SomeFunction(FileCreationInformation fileCreationInformation)
    {
        var url = fileCreationInformation.Url; 
                
        // Check the value of url variable above. It should be set to ThisisTest
    
        fileCreationInformation.Url = value; // This statement had no effect on fileCreationInformation.Url value
    }
