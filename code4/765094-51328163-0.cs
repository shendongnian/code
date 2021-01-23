    //Create an expando object and create & assign values to all the fields that exists in your interface
    dynamic sigObj = new ExpandoObject();
    sigObj.EmployeeKey = 1234;
    
    //Create the object using "ActLike" method of the Impromptu class
    INewSignatureAcquired sig = Impromptu.ActLike<INewSignatureAcquired>(sigObj);
