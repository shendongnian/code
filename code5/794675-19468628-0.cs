      private void DoSomethingOnTheUiThread()
            {
                Dispatcher.BeginInvoke((Action) (() =>
                    {
                        // your code goes here...
                        Window w = new Window();
                        w.Show();
                    }));
            }
