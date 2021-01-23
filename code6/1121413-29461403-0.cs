    void loadpicture()
                {
                    
        
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "select pic from EmployeeInfo where FirstName = '" + listBox1.Text + "'";
                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    byte[] content = (byte[])ds.Tables[0].Rows[0].ItemArray[0];
                    MemoryStream stream = new MemoryStream(content);
                    pb1.Image = Image.FromStream(stream);
                    
                }
