    [System.Web.Services.WebMethod]
         public static string GetDropDownDataWM(string name)
         {
             //return "Hello " + name + Environment.NewLine + "The Current Time is: "
             //    + DateTime.Now.ToString();
             var msg = "arbaaz";
             string[] name1 = new string[1];
             string[] Value = new string[1];
             name1[0] = "@Empcode";
             Value[0] = HttpContext.Current.Session["LoginUser"].ToString().Trim();
             DataSet ds = new DataSet();
             dboperation dbo = new dboperation();
             ds = dbo.executeProcedure("GetDropDownsForVendor", name1, Value, 1);
             return DataSetToJSON(ds); 
         }
    public static string DataSetToJSON(DataSet ds)
    {
        Dictionary<string, object> dict = new Dictionary<string, object>();
        foreach (DataTable dt in ds.Tables)
        {
            object[] arr = new object[dt.Rows.Count + 1];
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                arr[i] = dt.Rows[i].ItemArray;
            }
            dict.Add(dt.TableName, arr);
        }
        var lstJson = Newtonsoft.Json.JsonConvert.SerializeObject(dict);
        return lstJson;
    }
