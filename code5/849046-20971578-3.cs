    // note, "async void" is normally only good for async event handler
    async void buttonTest_Click(object sender, EventArgs e)
    {
        try
        {
            var task = DownloadStringAsync("http://example.com"); // for example 
            // Wrong: task.Wait();      
            await task;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
