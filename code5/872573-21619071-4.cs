    protected string ImagePath(string tableCodeUrl,string imageColumnValue)
    {
        string url=string.empty;
        if(imageColumnValue=="")
            url="defaultImagePath"; // Give path to default image
        else
            url = tableCodeUrl;
        
        return url;
    }
