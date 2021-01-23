    using (var client = new HttpClient(...))
    {
        // long-running download operation, but UI remains responsive because
        // the operation executes asynchronously
        var response = await client.GetAsync();
        // control resumes here once the above completes,
        // returning control to the UI thread.
        this.TextField.Text = "Download Complete!";
    }
