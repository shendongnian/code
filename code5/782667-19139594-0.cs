    private async void ButtonClicked()
    {
         var task = Task<bool>.Factory.StartNew(() =>
         {
                WorkStarted(this, new EventArgs());
                Thread.Sleep(5000);
                WorkComplete(this, null);
                return true;
         });
         await task;//Wait Asynchronously
         if (task.Result) MessageBox.Show("Success!");//this line causes app to block
    }
