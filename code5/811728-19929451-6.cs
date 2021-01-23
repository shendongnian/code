    public int CallSomeServiceAndReturnItsValue()   
    {
        int result = 0;
        WebService.SomeAsyncServiceCall((svcResult) => { result = svcResult.Value; });
        return result;
    }
