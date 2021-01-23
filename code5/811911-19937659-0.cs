    [DataMember(Name = "description"]
    private object _description;
    public string Description
    {
        get
        {
            if (_description != null)
            {
                if (_description is string)
                {
                    // Do Nothing
                    // You can remove this, just putting this here to 
                    //   show conditional is implicit
                }
                else if (_description is string[])
                {
                    // Join string[] using '\n\n' as the connector
                    _description = string.Join("\n\n", (string[])_description);
                }
            }
            return _description as string;
        }
    }
