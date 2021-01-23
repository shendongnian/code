    var col1 = new NameValueCollection
    {
        { "IsVisible", "True" },
        { "Editable", "True" },
        { "Revisable", "True" },
        { "tblId", "100" },
    };
    
    var col2 = new NameValueCollection
    {
        { "IsVisible", "True" },
        { "Editable", "" },
        { "Revisable", "True" },
        { "tblId", "101" },
    };
    var formCollection = new FormCollection
    {
        col1,
        col2
    };
    
    var length =
        formCollection
            .Cast<string>()
            .Select(entry => formCollection.GetValues(entry).Length)
            .Max();
