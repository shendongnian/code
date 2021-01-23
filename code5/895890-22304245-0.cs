    new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
              
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        Loading.Content = "Loading";
                    }));
                
                Thread.Sleep(500);
                this.Dispatcher.Invoke((Action)(() =>
                {
                    Loading.Content = "Loading.";
                }));
                Thread.Sleep(500);
                this.Dispatcher.Invoke((Action)(() =>
                {
                    Loading.Content = "Loading..";
                }));
                Thread.Sleep(500);
                this.Dispatcher.Invoke((Action)(() =>
                {
                    Loading.Content = "Loading...";
                }));
                Thread.Sleep(500);
            
            }).Start();
