        bool closeInitiated = false;
        private void poc_Closing(object sender, CancelEventArgs e)
        {
            if (!closeInitiated)
            {
                var task1 = System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    myfunction();
                }).ContinueWith((cc) => { });
                closeInitiated = true;
                e.Cancel = true;
            }
        }
        private void myfunction()
        {
            App.Current.Dispatcher.Invoke(new Action(() =>
                {
                    MessageBox.Show("test");
                    Close();
                }));
        } 
