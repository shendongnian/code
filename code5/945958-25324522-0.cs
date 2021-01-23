       var timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 50) };
            timer.Start();
            timer.Tick += (sender, args) =>
                {
                    try
                    {
                        if (this.client.State == CommunicationState.Faulted)
                        {
                            this.RegisterTerminal();
                        }
                        this.client.KeepConnection();
                    }
                    catch
                    {
                        throw new Exception("Failed to establish connection with server");
                    }
                };
