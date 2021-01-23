    [WebMethod(EnableSession = true)]
    public static void SetAmountInSession(int amount)
    {
        HttpContext.Current.Session["amount"] = amount;
    }
