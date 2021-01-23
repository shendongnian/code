     public async Task Method()
            {
                await Task.Run(() =>
                {
                    //operations
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        //grab the UI Dispatcher if you need
                    });
                }).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        //operations success
                    }
                    else if (task.IsFaulted)
                    {
                        //operations failed
                    }
                });
            }
