    public List<string> GetResponses(params string[] addresses)
    {
        var result = new List<string>();
        var skipCount = 0;
        var takeCount = addresses.Length < 5000 ? 1000 : 5000;
        string[] request;
        while ((request = addresses.Skip(skipCount).Take(takeCount).ToArray()).Length > 0)
        {
            skipCount += takeCount;
            result.Add(service.Request(request));
        }
        return result;
    }
