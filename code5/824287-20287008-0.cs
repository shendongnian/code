    public static string WhoAmI([CallerMemberName] string caller=null)
    {
        return caller;
    }
    ...
    public string FindMyName
    {
        get
        {
            string thisPropertyName = WhoAmI();
            //...
        }
    }
