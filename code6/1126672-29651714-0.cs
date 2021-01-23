     [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    [WebMethod]
    public void getCustomers() {
      //  var json = "";
        Context.Response.Clear();
        Context.Response.ContentType = "application/json"; 
        var clientes = from result in dados.clientes select result;
        JavaScriptSerializer jss = new JavaScriptSerializer();
        
        Context.Response.Write(jss.Serialize(clientes));
              
    }
