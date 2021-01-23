    private void saveAdd()
    {
        backgroundWorker.RunWorkerAsync(); // loading bar
        // remove saving code, move it to DoWork event
    }
    private void backgroundWorkerDoWork(object sender, DoWorkEventArgs e)
    {
        DBconnection dbConString = new DBconnection();
        FbConnection dbConnect = new FbConnection(dbConString.getConnectionString()); 
        // rest of your code ......
        finally
        {
            dbConnect.Close();
        }
    }
