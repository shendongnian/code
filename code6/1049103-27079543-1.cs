    using Kvp = System.Collections.Generic.KeyValuePair<string, object>;
    ....
    public void AskServer(string url, List<Kvp> kvps)
    {
        WWWForm form = new WWWForm(url);
        foreach (var arg in kvps)            
            form.Addfield(arg.Key, arg.Value);            
    }
