    async void Button_Click(object s, EventArgs args)
    {
        try
        {
            await _draw.RunAsync(async (token) =>
            {
                var progressWindow = new Window();
                progressWindow.Show();
                var progress = new Progress<int>((i) => 
                    { /* update the progress inside the progressWindow */});
                try
                {
                    // do the long-running task
                    await this.DrawContent(this.TimePeriod, progress, token);
                }
                finally
                {
                    // hide the progress
                    progressWindow.Close();
                }
            }, CancellationToken.None);
        }
        catch (Exception ex)
        {
            while (ex is AggregateException)
                ex = ex.InnerException;
            if (!(ex is OperationCanceledException))
                MessageBox.Show(ex.Message);
        }
    }
