    Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                //Show messagebox
                var result = MessageBox.Show("Question?", "Title", MessageBoxButton.OKCancel);
                //Check messagebox result
                if (result == MessageBoxResult.OK)
                {
                    ThreadPool.QueueUserWorkItem(x =>
                    {
                        //Do some work, transfer a file
                    });
                }
            });
   
