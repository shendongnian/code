    Deployment.Current.Dispatcher.BeginInvoke(delegate
    {
      var mbr = MessageBox.Show("Are you sure you want to leave this page?", "Warning",      
      MessageBoxButton.OKCancel);
      if(mbr == MessageBoxResult.OK)
      {   OK pressed  } 
      else
      {   Cancel pressed  }
            
    });
 
