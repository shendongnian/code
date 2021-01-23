      protected void Timer1_Tick(object sender, EventArgs e)
            {
                con = new MySqlConnection(conStr);
                con.Open();
                cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = con;
                con = new MySql.Data.MySqlClient.MySqlConnection(conStr);
    
                //Auto refesh database
                GridView1.DataSourceID = "Datacmd";
    
                //Auto get status(cells[7]) of pid(cells[6])
                count = GridView1.Rows.Count;
                string server = "";
                string pid = "";
                string status = "";
    
                for (int i = 0; i < count; i++)
                {
                    server = GridView1.Rows[i].Cells[1].Text;
                    switch (server)
                    {
                        //server locahost
                        case "localhost":
                            pid = GridView1.Rows[i].Cells[6].Text;
                            status = ws.GetStatusProcess(pid);
                            string SQL = "UPDATE command SET status='" + status + "' WHERE id=" + int.Parse(GridView1.Rows[i].Cells[0].Text) + "";
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                            con.Close();
                            GridView1.DataSourceID = "Datacmd";
                            break;
    
                        default:
                            break;
                    }
                }
            }
    [http://www.codeproject.com/Questions/359958/how-to-use-timer-in-asp-net][1]
