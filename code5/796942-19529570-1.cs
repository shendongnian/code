            private void TestConnection_Click(object sender, RoutedEventArgs e)
        {
            string con_str = "Server=" + Ip.Text + ";Port=" + Port.Text + ";Database=hospital;Uid=" + login.Text + ";Pwd=" + password.Text + ";";
            var dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            var task = new Task(() => TryConnect(con_str));
            task.ContinueWith(task1 =>
                {
                    //TODO Handle exception
                    System.Diagnostics.Trace.WriteLine(task1.Exception);
                    //or if you really want an messageBox, pass it back to the ui thread
                    dispatcher.Invoke(() => MessageBox.Show(task1.Exception.Message));
                }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }
