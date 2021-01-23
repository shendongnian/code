    private void btnTwoConnectionsNested_Click(object sender, EventArgs e)
    {
        string connectionString = @"Data Source=" + tbServer.Text
            + @";Initial Catalog=master;Integrated Security=True; timeout=0";
     
        using (TransactionScope transactionScope = new TransactionScope())
        {
            SqlConnection connectionOne = new SqlConnection(connectionString);
            SqlConnection connectionTwo = new SqlConnection(connectionString);
     
            try
            {
                //2 connections, nested
                connectionOne.Open();
                connectionTwo.Open(); // escalates to DTC on 05 and 08
                connectionTwo.Close();
                connectionOne.Close();
     
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            finally
            {
                connectionOne.Dispose();
                connectionTwo.Dispose();
            }
        }
    }
