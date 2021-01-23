    DataTable dts = get_banner_detail_service("");
            DataTable dtc = get_banner_detail_cat("");
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> rowss;
            Dictionary<string, object> rowsc;
            List<object> rowsin;
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            rowsc = new Dictionary<string, object>();
            foreach (DataRow dr in dtc.Rows)
            {
                string cat = dr["Category"].ToString();
    
                var filteredAndroid = (from n in dts.AsEnumerable()
                                       where n.Field<string>("Category").Contains(cat)
                                       select n).ToList();
    
                if (filteredAndroid.Count != 0)
                {
                    DataTable t = filteredAndroid.CopyToDataTable();
    
                    t.Columns.Remove("Category");
                    rowss = new Dictionary<string, object>();
    
                    rowsin = new List<object>();
                    foreach (DataRow drr in t.Rows)
                    {
                        foreach (DataColumn col in t.Columns)
                        {
                            rowss.Add(col.ColumnName, drr[col]);
                        }
                        rowsin.Add(rowss);
                        rowss = new Dictionary<string, object>();
    
                    }
                    rowsc.Add(cat, rowsin);
                    t.Dispose();
                    t = null;
                    filteredAndroid = null;
                }
            }
            rows.Add(rowsc);
    
            string json = JsonConvert.SerializeObject(rows, Newtonsoft.Json.Formatting.Indented);
            if (json.Length > 2)
            {
                json = json.Substring(1, json.Length - 2);
            }
            Response.Write(json);
            Response.Flush();
            Response.End();
