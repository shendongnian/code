            var folder = Server.MapPath("~/temp/");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (FileUpload1.HasFile)
            {
                string path = string.Concat((Server.MapPath("~/temp/" + FileUpload1.FileName)));
                
                
                FileUpload1.PostedFile.SaveAs(path);
                OleDbConnection OleDbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;");
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", OleDbcon);
                //OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$a2:j]", OleDbcon);
                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);
                OleDbcon.Open();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                objAdapter1.Fill(ds);
                dt = ds.Tables[0];
                OleDbcon.Close();
                int number_of_columns = dt.Columns.Count;
                
                string[] columnNames = new string[number_of_columns];
                int k;
                for (k = 0; k < number_of_columns; k++)
                {
                    columnNames[k] = dt.Columns[k].ToString();
                }
                
                if (columnNames[0] == "v"|| columnNames[1] == "Condom" || columnNames[2] == "Lubricant")
                {
                    OleDbCommand cl_cmd = new OleDbCommand("SELECT * FROM [Sheet1$a2:j]", OleDbcon);
                    OleDbDataAdapter objAdapter2 = new OleDbDataAdapter(cl_cmd);
                    OleDbcon.Open();
                    DataSet ds1 = new DataSet();
                    DataTable dt1 = new DataTable();
                    objAdapter2.Fill(ds1);
                    dt1 = ds1.Tables[0];
                    OleDbcon.Close();
                    int number_of_columns1 = dt1.Columns.Count;
                    string[] columnNames1 = new string[number_of_columns1];
                    int number_of_rows = ds1.Tables[0].Rows.Count;
                    string[,] sheetEntries = new string[number_of_rows, number_of_columns];
                    for (int j = 0; j < number_of_columns1; j++)
                    {
                        columnNames1[j] = dt1.Columns[j].ToString();
                    }
                    for (int i = 0; i < number_of_rows; i++)
                    {
                        for (int j = 0; j < number_of_columns1; j++)
                            sheetEntries[i, j] = dt1.Rows[i].ItemArray.GetValue(j).ToString();
                    }
                    string strSQL1 = null;
                    for (int i1 = 0; i1 < number_of_rows; i1++)
                    {
                        if (columnNames[1] == "Condom")
                        {
                            strSQL1 = "INSERT INTO [import_test]([dic_code],[condom_receive],[lubricant_receive]) VALUES ("
                                   + sheetEntries[i1, 0] + ",'" + sheetEntries[i1, 1] + "'," + 0 + ");";
                            SqlCommand cmd1 = new SqlCommand(strSQL1);
                            dc.Open();
                            cmd1.Connection = dc.GetConnection();
                            cmd1.ExecuteNonQuery();
                            Array.ForEach(Directory.GetFiles((Server.MapPath("~/temp/"))), File.Delete);
                            Label1.ForeColor = Color.Green;
                            Label1.Text = "Successfully inserted";
                            dc.Close();
                        }
                        if (columnNames[2] == "Lubricant")
                        {
                            strSQL1 = "INSERT INTO [import_test]([dic_code],[condom_receive],[lubricant_receive]) VALUES ("
                                   + sheetEntries[i1, 0] + ",'" + 0 + "'," + sheetEntries[i1, 1] + ");";
                            SqlCommand cmd1 = new SqlCommand(strSQL1);
                            dc.Open();
                            cmd1.Connection = dc.GetConnection();
                            cmd1.ExecuteNonQuery();
                            Array.ForEach(Directory.GetFiles((Server.MapPath("~/temp/"))), File.Delete);
                            Label1.ForeColor = Color.Green;
                            Label1.Text = "Successfully inserted";
                            dc.Close();
                        }
                    }
                }
            }
            else
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Please select the File";
            }
        }
