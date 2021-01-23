    if(TestInternetConnection.connectionTrue.Equals(true) && string.IsNullOrEmpty(endPoint1))
    {
        Debug.Log("connection is true");
    }
    
    if(TestInternetConnection.connectionFalse.Equals(false) && (string.IsNullOrEmpty(endPoint1) || endPoint1 != null))
    {
        Debug.Log("connection is false");
    }
