    public async void Test()
    {
        for (int i = 0; i < 100; i++)
        {
            SomeClass result = await SomeMethod(string.Empty);
        }
    }
    
    private async Task<SomeClass> SomeMethod(string param)
    {
       return await Task.FromResult<SomeClass>(new SomeClass());
    }
