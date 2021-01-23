    SqlCommand sqlCmd = new SqlCommand(sql, sqlCon);
                    sqlCmd.CommandTimeout = 0;
                    SqlDataReader dr;
                    dr = sqlCmd.ExecuteReader();
                    MyDDLst.Items.Insert(0, "--Select--");
                    while (dr.Read())
                        MyDDLst.Items.Add(dr[0].ToString());
