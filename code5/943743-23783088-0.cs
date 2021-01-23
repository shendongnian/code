            OleDbConnection conn = new OleDbConnection();
            //This is making a connection to the excel file, don't worry about this I think you did it differently.
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + stringFileName + ";" + "Extended Properties=\"Excel 12.0;HDR=Yes;\"";             OleDbCommand cmd = new OleDbCommand
            ("SELECT * FROM [" + sheetFromTo + "]", conn);
            DataSet dataSet1 = new DataSet();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            try
            {
                conn.Open();//opens connection
                    dataSet1.Clear();//empties, incase they refill it later
                    dataAdapter.SelectCommand = cmd;//calls the cmd up above
                    dataAdapter.Fill(dataSet1);//fills the dataset
                    dataGridView1.DataSource = dataSet1.Tables[0];//puts the dataset in the dataGridview
                    //important** creates a datatable from the dataset, most of our work with the server is with this datatable
                    DataTable dataTable = dataSet1.Tables[0];
                    DataTable = dataTable;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
