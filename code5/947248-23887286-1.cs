    [WebMethod(EnableSession = true, MessageName = "testMethod"))]
    public string testMethod(string param1, string param2)
    {
          .......
    }
    [WebMethod(EnableSession = true, MessageName = "testMethod")]
    public string testMethod(string param1)
    {
          testMethod(param1, "default value");
    }
