    public Task<string> MyExtension(this string s) { ... }
    
    public async void MyCallingMethod()
    {    
        string result = await "hi".MyExtension();
    }
