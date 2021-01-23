    private async void btnProcess_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "Please wait...";
        await doSomeWorkAsynchronously();
        lblStatus.Text = "Work completed";
    }
    private async Task doSomeWorkAsynchronously()
    {
        await Task.Run(()=>
        {
            // Do all your slow work here.
            Thread.Sleep(2000); // Simulate slow work.
        });
    }
