    public string setJsonValue()
    {
       string data = Request.Params["jsonData"];
       return data;
       //System.Web.HttpContext.Current.Session[param] = value;            
    }
