    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath + ";" + "Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
                OleDbConnection oledbconnection = new OleDbConnection(connectionString);
    
                    oledbconnection.Open();
                    OleDbCommand oledbcommand = new OleDbCommand("SELECT * FROM [StudentInformationSheet$]", oledbconnection);
                    oledbadapter = new OleDbDataAdapter(oledbcommand);
                    ds = new DataSet();
                    oledbadapter.Fill(ds, "Passengers");
                    DataTable dt = ds.Tables[0];
                    DataTable dtCloned = dt.Clone();
    
                    dtCloned.Columns[0].DataType = typeof(string);
                    dtCloned.Columns[1].DataType = typeof(string);
    
                    foreach (DataRow row in dt.Rows)
                    {
                        dtCloned.ImportRow(row);
                    }
                    GridViewPassenger.DataSource = dtCloned.DefaultView;
                    oledbconnection.Close();
