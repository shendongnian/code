            var applicationStartWatcher = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            applicationStartWatcher.EventArrived += (sender, args) =>
                {
                    if (args.NewEvent.Properties["ProcessName"].Value.ToString().StartsWith("SnippingTool"))
                    {
                        Dispatcher.Invoke(() => this.Visibility = Visibility.Hidden);
                    }
                };
            applicationStartWatcher.Start();
            var applicationCloseWatcher = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
            applicationCloseWatcher.EventArrived += (sender, args) =>
            {
                if (args.NewEvent.Properties["ProcessName"].Value.ToString().StartsWith("SnippingTool"))
                {
                    Dispatcher.Invoke(() =>
                        {
                            this.Visibility = Visibility.Visible;
                            this.Activate();
                        });
                }
            };
            applicationCloseWatcher.Start();
