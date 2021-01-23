    [WebMethod]
    public static string DoSomething(string str1, string str2)
    {
        string result = "This is concatenation of " + str1 + " and " + str2 + "'.";
        return result;
    }
