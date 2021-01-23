    private void btnGetStatus_Click(object sender, EventArgs e)
    {
        // Check if a runner has been selected
        if (lstRunners.SelectedIndex > -1)
        {
            // Obtain selected runner
            Runner selectedRunner = (Runner)lstRunners.SelectedItem;
            // Call the method in Runner class to get the runner's status
            lblRunnerInfo.Text = selectedRunner.GetStatus(selectedRunner);
        }
    }
