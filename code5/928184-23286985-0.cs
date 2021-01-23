    private void RequestInfo(string a, string b)
    {
       var c = a+b;
       library.FetchInfo(c, obj => dictionaryOfInfo.Add(c, obj));
    }
