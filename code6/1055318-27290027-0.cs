    public string GetJSONDataForRouteInfo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=HITSEDGE\HITSEDGE;Initial Catalog=CCIL1;User ID=dbassist;Password=assist@123"))
            {
                using (SqlCommand cmd = new SqlCommand("select [Route No_] as Routeno,[Description],[Duration],[KM Coverage],[Mileage],[Allowance],[Repair And Maintenance] from dbo.[CRONUS International Ltd_$Route]", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);  
                    System.Web.Script.Serialization.JavaScriptSerializer serializer = new    System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                       row = new Dictionary<string, object>();
                       foreach (DataColumn col in dt.Columns)
                       {
                         row.Add(col.ColumnName, dr[col]);
                       }
                       ws.Add(row);
                     }
                      return serializer.Serialize(rows);                    
                }
            }
        }
