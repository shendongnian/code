    [WebMethod]
    public static void GetPerson()
    {
        Person p = new Person() 
        {
            Id = 1,
            Name = "Test"
        };
        HttpContext.Current.Response.ResponseType = "application/json";
        HttpContext.Current.Response.Write(JsonConvert.SerializeObject(p));
        HttpContext.Current.Response.End();
    }
