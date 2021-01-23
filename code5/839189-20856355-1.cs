     public class jqGridHandler : IHttpHandler
         {
    
        public void ProcessRequest(HttpContext context)
        {
            MyFirstService.Service1Client client = new MyFirstService.Service1Client();
            context.Response.Write(client.GetJsonUsers());
        }
    
        private DataSet GetUsersFromDB()
        {
            AccessDataBase reader = new AccessDataBase();
            string selectquery = "SELECT * FROM Registration";
            return reader.readDB(selectquery);
        }
    
        public string GetJsonUsers()
        {
            return GetJson(GetUsersFromDB());
        }
    
    
        private string GetJson(DataSet dt)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows =
              new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataTable dtt in dt.Tables)
                foreach (DataRow dr in dtt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dtt.Columns)
                    {
                        row.Add(col.ColumnName.Trim(), dr[col]);
                    }
                    rows.Add(row);
                }
    
            return serializer.Serialize(rows);
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
