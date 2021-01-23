        public List<GSP> GetOwnAirline()
        {
            List<GSP> lstGSP = new List<GSP>();
            using (ccs = new SqlConnection(Adm.COnnectionString))
            {
                string get_ = "SELECT * FROM " + Adm.schema_ + "Adm.GSP WHERE Description = 'Own Airline'";
                using (SqlCommand cmd = new SqlCommand(get_, ccs))
                {
                    ccs.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rdr.Read())
                    {
                        GSP objGSP = new GSP();
                        Fill(objGSP, rdr);//method
                        lstGSP.Add(objGSP);
                    }
                    ccs.Close();
                }
            }
            return lstGSP;
        }
    public static void Fill(object LogicObject, System.Data.SqlClient.SqlDataReader SqlDataReader)
            {
                Dictionary<string, PropertyInfo> props = new Dictionary<string, PropertyInfo>();
                foreach (PropertyInfo p in LogicObject.GetType().GetProperties())
                    props.Add(p.Name, p);
                //foreach (System.Data.DataColumn col in Row.Table.Columns)
    
                for (int i = 0; i < SqlDataReader.FieldCount; i++)
                {
                    string name = SqlDataReader.GetName(i);
                    if (SqlDataReader[name] != DBNull.Value && props.ContainsKey(name))
                    {
                        object item = SqlDataReader[name];
                        PropertyInfo p = props[name];
                        if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            if (p.PropertyType != SqlDataReader.GetFieldType(i))
                                item = Convert.ChangeType(item, p.PropertyType.GetGenericArguments()[0]);
    
                        }
                        else
                        {
                            if (p.PropertyType != SqlDataReader.GetFieldType(i))
                                item = Convert.ChangeType(item, p.PropertyType);
                        }
    
                        p.SetValue(LogicObject, item, null);
                    }
    
                }
            }
