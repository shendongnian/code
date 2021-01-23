     Task tsk = Task.Factory.StartNew(() =>
            {
                // Some code here to create chunk
                for (var chunk in chunks)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        yourCollection.Add(chunk);
                        }), DispatcherPriority.Background);
                    });
                }
            });
