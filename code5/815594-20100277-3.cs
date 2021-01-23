    private void CallSpButton_Click(object sender, EventArgs e)
    {
        CallSpButton.Enabled = false;
        SpCaller.RunWorkerAsync();
    }
    private void SpCaller_DoWork(object sender, DoWorkEventArgs e)
    {
        var self = (BackgroundWorker) sender;
        var cb = new SqlConnectionStringBuilder
        {
            DataSource = ".", 
            InitialCatalog = "Sandbox", 
            IntegratedSecurity = true
        };
        using (var cn = new SqlConnection(cb.ToString()))
        {
            cn.FireInfoMessageEventOnUserErrors = true;
            cn.Open();
            cn.InfoMessage += (o, args) => self.ReportProgress(0, args.Message);
            using (var cmd = cn.CreateCommand())
            {
                cmd.CommandText = "usp_LongProcess";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
    }
    private void SpCaller_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        CallSpButton.Enabled = true;
    }
    private void SpCaller_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var message = Convert.ToString(e.UserState);
        Debug.WriteLine(message);
        statusLabel.Text = message;
        if (message.EndsWith(" PERCENT COMPLETE"))
        {
            int percent;
            if (int.TryParse(message.Split(' ')[0], out percent))
                progress.Value = percent;
        }
    }
