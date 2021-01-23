    Public class model
    {
    Public Dictionary<string,string> filter{get;set;}
    Public Dictionary<string,string> sorting{get;set;}
    Public int sorting{get;set;}
    }
    
    public async IHttpActionResult Get(model yourModel)
    {
            //...
    }
