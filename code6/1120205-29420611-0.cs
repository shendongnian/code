    // We go to a non-UI thread
    TaskEx.Run(() => {
        for (int i = 1; i <= 1000000; i++)
        {
            // some long operation here... -_-"
            if (i % 2 == 0)
            {
                // We return to UI thread after long operation to display the result
                Deployment.Current.Dispatcher.InvokeAsync(() => {
                    TextBlock.Text += string.Format("{0},", i);
                });
            }
        }
    });
