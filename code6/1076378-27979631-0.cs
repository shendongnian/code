    private void btnDataSync_Click(object sender, EventArgs e)
    {
        // Start the asynchronous operation.
        backgroundWorker1.RunWorkerAsync();
        btnDataSync.Enabled = false;
        btnDataSync.Text = "Please Wait...";
        bool success = false;
        try
        {
            // Execute the query asynchronously
            success = await Task.Run(() => ExecuteLocalToLive());
        }
        catch (Exception ex)
        {
           MessageBox.Show("Please check your internet connection and try again!!!");
        }
        btnDataSync.Enabled = true;
        btnDataSync.Text = success ? "Success" : "Failure";
    }
    private bool ExecuteLocalToLive()
    {
        bool success = false;
        con.GetConnectLive();
        con.GetConnect();
        if (con.CnLive.State == ConnectionState.Open)
        {
            MessageBox.Show("Connection to Live Server Successful!!!...Data Synchronisation may take several minutes so do not cancel the operation while in execution mode");
            string Str = "RMS_LocalToLive";
            cmd = new SqlCommand(Str, con.Cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 1200;
            rowCount = cmd.ExecuteNonQuery();
            if (rowCount > -1)
            {
                MessageBox.Show("Total no. of rows synchronised = " + rowCount);
                success = true;
            }
            else
            {
               MessageBox.Show("Data Synchronisation couldn't be completed because of connection problem... Please try again!!!");
            }
        }
        else
        {
           MessageBox.Show("Unable to connect to Live Server...Please check your internet connection and try again!!!");
        }
        con.GetDisConnect();
        con.GetDisConnectLive();
        return success;
    }
