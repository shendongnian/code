    public class HelloWorldData
        {
            public String Message;
        }
    
        [WebMethod]
        public void getCustomers()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            HelloWorldData data = new HelloWorldData();
            string sql = "SQL_QUERTY";
            SqlDataAdapter da = new SqlDataAdapter(sql, System.Configuration.ConfigurationManager.AppSettings["CONNECTION_STRING"]);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }
