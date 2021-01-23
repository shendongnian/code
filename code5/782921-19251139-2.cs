    private IEnumerable<YourModel> GetMyData()
    {
        var dataItems = HttpContext.Cache["someKey"] as IEnumerable<YourModel>;
        if (dataItems == null)
        {
            // nothing in the cache => we perform some expensive query to fetch the result
            dataItems = fooRepository.GetAll().Select(x => new YourModel(){ Value = x.Id, Text = x.Name };
    
            // and we cache it so that the next time we don't need to perform the query
            HttpContext.Cache["someKey"] = dataItems ;
        }
    
        return dataItems;
    }
