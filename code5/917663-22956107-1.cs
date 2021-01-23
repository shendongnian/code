    [System.Web.Services.WebMethod]
    public static string GetDropDownDataWM(string name)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add("Table0");
        ds.Tables[0].Columns.Add("OptionValue");
        ds.Tables[0].Columns.Add("OptionText");
        ds.Tables[0].Rows.Add("0", "test 0");
        ds.Tables[0].Rows.Add("1", "test 1");
        ds.Tables[0].Rows.Add("2", "test 2");
        ds.Tables[0].Rows.Add("3", "test 3");
        ds.Tables[0].Rows.Add("4", "test 4");
    
        return ds.GetXml();
    }
