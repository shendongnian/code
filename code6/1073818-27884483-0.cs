    private void ProcessThisEmployee(Employee x, CancellationToken token)
    {
        ThirdPartyLibrary library = new ThirdPartyLibrary();
        token.ThrowIfCancellationRequested();
        using(token.Register(() => library.Clean())
        {
            library.SomeAPI(x);
        }
        token.ThrowIfCancellationRequested(); //Not sure why you cancel here in your original example.
    }
