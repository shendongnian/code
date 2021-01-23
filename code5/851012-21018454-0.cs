      [WebMethod]
            public static string getGuestByGuestIDFront(string guest_id)
            {
                DataTable dt = BAL.getGuestByGuestID(guest_id);
    
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row = null;
    
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
    
                string json = js.Serialize(rows);
                return json;
            }
