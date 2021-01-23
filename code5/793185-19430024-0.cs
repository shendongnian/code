    proxy = newServiceReference1.ServiceDataContractTestClient(); 
    try
    { 
        proxy.MetodThrowsException();
        proxy.Close(); 
    } 
    catch
    { 
        proxy.Abort(); 
        throw; // Or handle exception
    }
