    public static void DynamicExecution(String assemblyFileName, String uniqueDomName)
    {
        Boolean retVal = false;
        
            AppDomain newDomain = AppDomain.CreateDomain(uniqueDomName);
            YourClass yourClass = (YourClass)newDomain.CreateInstanceFromAndUnwrap(assemblyFileName, "YourClass");
            //do what you need with yourClass Object
            AppDomain.Unload(newDomain);
            newDomain = null;
    }
