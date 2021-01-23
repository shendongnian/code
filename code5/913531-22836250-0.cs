    public string GetEmployees()
            {
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NSConstr"].ToString());
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT *  FROM Contact e ";
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.Connection = con;
                da.Fill(dt);
                con.Close();
                
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row = null;
                foreach (DataRow rs in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, rs[col]);
                    }
                    rows.Add(row);
                }
                return serializer.Serialize(rows);
            }     
    
            public string errmsg(Exception ex)
            {
                return "[['ERROR','" + ex.Message + "']]";
            }
