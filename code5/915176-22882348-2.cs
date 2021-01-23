    [WebMethod]
    [HttpPost]
    public static bool UserNameExists(string sendData)
    {
        bool a;
        a = DataCheck.CheckDBUser(sendData);
        return a;
    }
