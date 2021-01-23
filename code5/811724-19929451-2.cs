    public int CallSomeServiceAndReturnItsValue()   
    {
        int identifier = await WebService.GetSomeIdentifier();
        return await WebService.GetResult(identifier);
    }
