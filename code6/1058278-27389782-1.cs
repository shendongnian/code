    public string SerializeObject(object toSerialize)
    {
        var settings = new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(), Formatting = Formatting.Indented };
        return JsonConvert.SerializeObject(toSerialize, Formatting.None, settings);
    }
        
    [HttpGet]
    public string GetUser()
    {
        var user = Simplic.Framework.Web.Security.UserManager.GetAllUser();
        return SerializeObject(user);
    }
