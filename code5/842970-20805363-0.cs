            IsBusy = true;
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                // save data
            }).ContinueWith((t) =>
            {
                // do more work
                IsBusy = false;
            }); 
