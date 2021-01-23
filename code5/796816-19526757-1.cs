    IMyInterface genericObject;
    
    if (!testFlag)
    {
        genericObject = new SpecificObject1();
    }
    
    if (testFlag)
    {
        genericObject = new SpecificObject2();
    }
    
    genericObject.FirstName = "Samuel";
    genericObject.LastName = "Jackson";
   
