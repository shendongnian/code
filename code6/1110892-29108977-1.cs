    private void Generate_Click(object sender, EventArgs e)
    {
        DisableButton(sender as Button, 5);
    }
    private async void DisableButton(Button sender, int secondsToDisable)
    {
        sender.Enabled = false;
        // In your code, you would kick off your long-running process here as a task
        await Task.Run(()=>Thread.Sleep(TimeSpan.FromSeconds(secondsToDisable)));
        sender.Enabled = true;
    }
