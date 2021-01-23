    private async void btnProcess_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "Please wait...";
        lblStatus.Text = await doSomeWorkAsynchronously();
    }
    private async Task<string> doSomeWorkAsynchronously()
    {
        return await Task.Run(()=>
        {
            // Do all your slow work here.
            Thread.Sleep(5000); // Simulate slow work.
            return "The task completed.";
        });
    }
