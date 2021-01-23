    private void bwExecuteProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        int Progress = Convert.ToInt16(Math.Floor(((Convert.ToDecimal(e.ProgressPercentage) / Convert.ToDecimal(txtPartsList.Lines.Count()))) * 100));
        lblTotal.Text = string.Format("Total Processed: {0} of {1}", e.ProgressPercentage, txtPartsList.Lines.Count());
        lblReaderTime.Text = string.Format("Time Elapsed (sec): {0}", (swMainProcess.ElapsedMilliseconds / 1000));
        pgsMain.Value = Progress;
    
        lblPercentComplete.Text = string.Format("Percent Complete: {0}%", Progress);
        ttpMain.SetToolTip(pgsMain, string.Format("{0}% Complete", Progress));
    }
