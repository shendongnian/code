                TextBox.IsEnabled = false;
                var t = new DispatcherTimer();
                t.Interval = new TimeSpan(0, 0, 1);
                t.Tick += (a, b) =>
                {
                    t.Stop();
                    TextBox.IsEnabled = true;
                };
                t.Start();
