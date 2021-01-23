    public Task<string> MyExtension(this string s) { ... }
    
    public async Task MyCallingMethod()
    {    
        string result = await "hi".MyExtension();
    }
