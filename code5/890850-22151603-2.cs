            new System.Threading.Timer((state) => 
            {
                Action action = () => timer_label.Content = DateTime.Now.ToString("hh:MM:ss");
                Dispatcher.BeginInvoke(action);
            }, null, 1000, 1000);
