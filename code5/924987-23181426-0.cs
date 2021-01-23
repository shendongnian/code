    public async Task Test() 
    {
        await Copy("test", "test2");
        DoPostCopied(whatever);
        await DoPostCopied2();//Etc
    }
