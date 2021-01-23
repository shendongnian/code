    protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
        e.Cancel = true;
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
          MessageBoxResult mbr = MessageBox.Show("Are you sure you want to leave this page?", "Warning", MessageBoxButton.OKCancel);
          if(mbr == MessageBoxResult.OK)
          {   OK pressed  } 
          else
          {   Cancel pressed  }
        });
    }
