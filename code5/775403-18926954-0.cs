        public static string Show(string prompt)
        {
            string input = null;
            var t = new Thread(() =>
            {
                Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    var inputBox = new InputBox(prompt);
                    inputBox.ShowDialog();
                    input = inputBox.Input;
                }));
                Dispatcher.CurrentDispatcher.InvokeShutdown();
            }) { IsBackground = true };
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            return input;
        }
