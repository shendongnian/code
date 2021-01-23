    [AllowAnonymous]
    [HttpGet()]
    public HttpResponseMessage GetAllItems(int moduleId)
    {
        HttpConfiguration config = new HttpConfiguration();
                config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
    
                try
                {
                    List<ItemInfo> itemList = GetItemsFromDatabase(moduleId);
                    return Request.CreateResponse(HttpStatusCode.OK, itemList, config);
                }
                catch (System.Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
    }
