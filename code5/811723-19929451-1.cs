    public int CallSomeServiceAndReturnItsValue()   
    {
        int result = 0;
        WebService.GetSomeIdentifier((svcResult) => 
           {
             var identifier = svcResult.Value; 
             WebService.GetResult(identifier, (anotherResult) =>
                {
                  result = anotherResult.Value;
                }
           }
        );
        return result;
    }
