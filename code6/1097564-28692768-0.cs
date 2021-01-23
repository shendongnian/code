            int colCount = dt.Columns.Count;
            foreach (DataRow dr in dt.Rows)
            {
                dynamic objExpando = new System.Dynamic.ExpandoObject();
                var obj = objExpando as IDictionary<string, object>;
                
                for (int i = 0; i < colCount; i++)
                {
                    string key = dr.Table.Columns[i].ColumnName.ToString();
                    string val = dr[key].ToString();
                    obj[key] = val;
                }
                rtn.Add(obj);
            }         
            String json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(rtn);
