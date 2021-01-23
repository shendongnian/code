    MySqlCommand mysqlcmd = new MySqlCommand("SELECT * FROM admin;", conn);
                MySqlDataAdapter mysqlad = new MySqlDataAdapter(mysqlcmd);
                DataSet ds = new DataSet();
                mysqlad.Fill(ds);
                DataTable dt = ds.Tables[0];
                player_list.DataSource = dt;
                int rowIndex = 0;
                foreach (DataRow row in dt.Rows)
                {
                    int i = 0;
                    
                    foreach (var item in row.ItemArray)
                    {
                        if (i == 0) {
                            player_list[0, rowIndex].Value = item.ToString();
                        }
                        if (i == 1) {
                            player_list[1, rowIndex].Value = item.ToString();
                        }
                        if (i == 4)
                        {
                            player_list[2, rowIndex].Value = item.ToString();
                        }
                        if (i == 7)
                        {
                            player_list[3, rowIndex].Value = item.ToString();
                        }
                        if (i == 8)
                        {
                            player_list[4, rowIndex].Value = item.ToString();
                        }
                        if (i == 9)
                        {
                            player_list[5, rowIndex].Value = item.ToString();
                        }
                        player_list[6, rowIndex].Value = "Remove";
                        ++i;
                    }
                    ++rowIndex;
                    i = 0;
                }
