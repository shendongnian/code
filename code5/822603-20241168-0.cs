    Task.Factory.StartNew(() =>
                {
                    //Copy file here
                }).ContinueWith((prevTask) =>
                    {
                        if (prevTask.Exception != null)
                        {
                            // log/display exception here
                            return;
                        }
                        //display success result here
                    }, TaskScheduler.FromCurrentSynchronizationContext());
