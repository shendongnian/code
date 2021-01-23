    private void closeButton_Click(object sender, EventArgs e)
    {
        if (calBackgroundWorker.IsBusy)
        {
            DialogResult dialogResult = MessageBox.Show("The Compass Calibration is already in progress, are you sure you wish to cancel?", "Stop Calibration", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                calBackgroundWorker.CancelAsync();
                this.DialogResult = DialogResult.OK;
            }
            return;
        }
        this.Close();
    }
