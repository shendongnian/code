        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Test4();
        }
        private void Test1()
        {
            while (true)
            {
                this.Title = DateTime.Now.ToString();
                System.Threading.Thread.Sleep(5000); //locks up app
            }
        }
        private void Test2()
        {
            var thd = new System.Threading.Thread(() => {
                while (true)
                {
                    this.Title = DateTime.Now.ToString(); //exception
                    System.Threading.Thread.Sleep(5000);
                }            
            });
            thd.Start();
        }
        private void Test3()
        {   //do the work on the background thread
            var thd = new System.Threading.Thread(() =>
            {
                while (true)
                {   //use dispatcher to manipulate the UI
                    this.Dispatcher.BeginInvoke((Action)(() 
                        => { this.Title = DateTime.Now.ToString(); 
                    }));
                    
                    System.Threading.Thread.Sleep(5000);
                    //there's nothing to ever stop this thread!
                }
            });
            thd.Start();
        }
        private async void Test4()
        {   //if you are using .Net 4.5 you can use the Async keyword
            //I _think_ any computation in your async method runs on the UI thread, 
            //so don't use this for ray tracing, 
            //but for DB or network access your workstation can get on with 
            //other (UI) work whilst it's waiting
            while (true)
            {
                await Task.Run(() => { System.Threading.Thread.Sleep(5000); });
                this.Title = DateTime.Now.ToString();
            }
        }
