    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                Thread t = new Thread(() =>
                {
                    Thread.Sleep(TimeSpan.FromSeconds(Helpers.GetRandomInt(1, 5)));
                    var value = sr.GetData();
                    Application.Current.Dispatcher.Invoke(
                        new Action(() => { txt1.Text += value + Environment.NewLine; }));
                });
                t.Start();
            }
        }
