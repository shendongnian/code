    public string Map(MapperContext context, string payLoad)
    {
        string verb = GetFirstWord(payLoad).ToUpper();
            
        switch (verb)
        {
            case "ECHO":
                return payLoad.Substring(verb.Length).TrimStart();
            case "COP":
                throw new FaultException("Only cops may use this service.", new FaultCode("FORBIDDEN"));
            case "BUG":
                throw new NullReferenceException();
        }
        throw new FaultException("Invalid request; first word must be 'ECHO', 'COP' or 'BUG'.", new FaultCode("BAD REQUEST"));
    }
    private string GetFirstWord(string request)
    {
        for (int i = 0; i < request.Length; i++)
        {
            if (char.IsWhiteSpace(request[i]))
            {
                return request.Substring(0, i);
            }
        }
        return request;
    }
