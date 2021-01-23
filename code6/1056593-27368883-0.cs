    private void viewLog_Click(object sender, EventArgs e)
        {
            
            try
            {
               if(statusDisplay.Lines.Count() > 1){
                    var total = statusDisplay.Lines.Count()-1;
                    for (int c = 0; c < total; c++)
                    {
                        //create a new connection
                        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = ElevatorStatusLog.mdb");
                        //open the connection
                        connection.Open();
                        //create a query
                        OleDbCommand command = new OleDbCommand("INSERT INTO StatusLog([DateTime],[Activities]) VALUES(@Parameter1, @Parameter2)", connection);
                        command.Parameters.Add(new OleDbParameter("@Parameter1", this.logtimeDispaly.Lines.ElementAt(c).ToString()));
                        command.Parameters.Add(new OleDbParameter("@Parameter2", this.statusDisplay.Lines.ElementAt(c).ToString()));
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
