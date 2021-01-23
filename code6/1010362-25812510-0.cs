     private void MethodThatWillCallComObject()
            {
                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    //this will call in background thread
                    return this.MethodThatTakesTimeToReturn();
                }).ContinueWith(t =>
                {
                    //t.Result is the return value and MessageBox will show in ui thread
                    MessageBox.Show(t.Result);
                }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            }
    
            private string MethodThatTakesTimeToReturn()
            {
                System.Threading.Thread.Sleep(5000);
                return "end of 5 seconds";
            }
