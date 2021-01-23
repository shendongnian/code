        public static DataTable ExecQuery(string query, List<SqlParam> sp_params, string db)
        {
            using (MySqlConnection sCon = new MySqlConnection())
            using (MySqlCommand command = new MySqlCommand())
            {
                sCon.ConnectionString = "server=" + server + ";port=" + port + ";database=" + db + ";uid=" + user + ";pwd=" + password + ";charset=utf8;";
                command.CommandType = CommandType.Text;
                command.Connection = sCon;
                if (sp_params != null)
                {
                    for (int i = 0; i < sp_params.Count; i++)
                    {
                        MySqlParameter sparam = new MySqlParameter();
                        sparam.ParameterName = sp_params[i].Name;
                        sparam.MySqlDbType = sp_params[i].Type;
                        sparam.Value = sp_params[i].Value;
                        command.Parameters.Add(sparam);
                    }
                }
                command.CommandText = query;
                sCon.Open();
                using (MySqlDataReader sd = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    for (int fc = 0; fc < sd.FieldCount; fc++)
                    {
                        if (dt.Columns.Contains(sd.GetName(fc)))
                        {
                            dt.Columns.Add(sd.GetName(fc) + "1", sd.GetFieldType(fc));
                        }
                        else
                        {
                            dt.Columns.Add(sd.GetName(fc), sd.GetFieldType(fc));
                        }
                    }
                    while (sd.Read())
                    {
                        DataRow dr = dt.NewRow();
                        for (int fc = 0; fc < sd.FieldCount; fc++)
                        {
                            dr[fc] = sd.GetValue(fc);
                        }
                        dt.Rows.Add(dr);
                    }
                    return dt;
                }
            }
        }
    }
