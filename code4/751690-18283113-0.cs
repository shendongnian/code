    protected string GetAmountStyle()
    {
        foreach (LFConnection ProdCurrConn in AllConn)
        {
            if (Login.Contains(ProdCurrConn.UserName) == false)
            {
                if ((Request.Browser.Browser.Contains("IE") == true))
                {
                    //th1.Attributes.Add("style", "padding-right: 5px;");
                    //return "padding-right: 1px;";
                    return "background-color: #FFFF66;";
                }
                else
                {
                    //th1.Attributes.Add("style", "padding-right: 5px;");
                    return "background-color: #FFFF66;";
                }
            }
            else
            {
                //th1.Attributes.Add("style", "padding-right: 5px;");
                return string.Empty;
            }
        }
        return string.Empty;
    }
