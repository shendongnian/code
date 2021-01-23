            private void Button_Click(object sender, RoutedEventArgs e)
            {
                var sync = SynchronizationContext.Current;
                BackgroundWorker w = new BackgroundWorker();
                w.DoWork+=(_, __)=>
                    {
                        //sync.Post(p => { button.Content = "Working"; }, null);
                        int j = 0;
                        for (int i = 0; i < 10; i++)
                        {
                            j++;
                            sync.Post(p => { button.Content = j.ToString(); }, null);
                            Thread.Sleep(1000);
                        }
                        sync.Post(p => { button.Background = Brushes.Aqua; button.Content = "Some Content"; }, null);
                    };
                w.RunWorkerAsync();
            }
