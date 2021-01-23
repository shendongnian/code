    void btnDoAsync_Click(object sender, EventArgs e)
    {
      var request = WebRequest.Create(tbxUrl.Text);
      
      request
      .GetResponseAsync()
      .ContinueWith
      (
        t => 
          WebRequest.Create(new StreamReader(t.Result.GetResponseStream()).ReadToEnd())
          .GetResponseAsync(),
        TaskScheduler.Default
      )
      .Unwrap()
      .ContinueWith
      (
        t =>
        {
          lblData.Text = new StreamReader(t.Result.GetResponseStream()).ReadToEnd();
        },
        TaskScheduler.FromCurrentSynchronizationContext()
      );
    }
