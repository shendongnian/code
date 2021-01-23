await Task.Run(() => MyMethod());
    async Task Main()
    {
        int i = await Task.Run( () => GetNumberD());
        i.Dump();
    }
    
    int GetNumberD()
    {
        return GetNumberC();
    }
    int GetNumberC()
    {
        return GetNumberB();
    }
    int GetNumberB()
    {
        return GetNumberA();
    }
    int GetNumberA()
    {
        return 7;
    }
