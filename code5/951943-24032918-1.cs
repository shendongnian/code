        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(delegate()
            {
                for (int i = 0; i < 100; i++)
                {
                    this.Dispatcher.Invoke(()=>
                    {
                        pbStatus.Value = i;
                    }); 
                    Thread.Sleep(500);
                }
            });
            t.Start();
        }
