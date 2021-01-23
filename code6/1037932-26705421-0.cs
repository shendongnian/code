    public void DoSomethingWithInternetConnection(InternetConnection internetConnection)
    {
        // Guard clause
        if(internetConnection == null)
        {
            throw new ArgumentNullException();
        }
        // Execute code that requires a valid internet connection
        internetConnection.DoSomething();
    }
