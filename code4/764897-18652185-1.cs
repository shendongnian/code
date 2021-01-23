        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                 new Thread(() =>
                {
                    Dispatcher.Invoke((Action)(() =>
                        {
                            Window2 w2 = new Window2();
                            w2.Show();
                        }));
                }).Start();
            new Thread(() =>
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    Window3 w3 = new Window3();
                    w3.Show();
                }));
            }).Start();
     }
