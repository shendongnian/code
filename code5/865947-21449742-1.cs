    private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        this.tsslDbError.Text = string.Empty;
        if (gc.logger.IsInfoEnabled)
            gc.logger.Info("btnIregPath_Click - Method End");
    }
    private void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            lblDbVersion.Text = string.Empty;
            getReleaseInfo(lblDbVersion);
        }
        catch (Exception ex)
        {
            this.tsslDbError.ForeColor = System.Drawing.Color.Red;
            lblDbVersion.Text = "iReg Release Information Not Available";
            this.tsslDbError.Text = "Unable to connect with iReg Database, Please contact iReg Suppot!";
            btnBrowse.Enabled = false;
            btnBackup.Enabled = false;
        }
    }
