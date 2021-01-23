     protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
     {
       var DoYouWantToQuit = MessageBox.Show("Are you sure you want to Quit", "Quit", MessageBoxButtons.OkCancel);
       if (DoYouWantToQuit != MessageBoxButton.Ok)
       {
          e.Cancel = true
       }
       base.OnBackKeyPress(e);
     }
