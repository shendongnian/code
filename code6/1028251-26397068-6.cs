    [HttpPost]
    public HttpResponseMessage PostData()
    {
        string text = Request.Content.ReadAsStringAsync().Result; 
        //log text           
        DataModel data = JsonConvert.DeSerialize<DataModel>(text);
    }
