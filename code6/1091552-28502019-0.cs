    private void AutentificateClick(Object sender, RoutedEventArgs e)
    {
        _btnOk.IsEnabled = false;
        Cursor = Cursors.Wait;         
        Task<Boolean>.Factory.StartNew(InitConnection).ContinueWith(t =>
        {        
             if (!t.Result)
                 return;
             // Emulate some work after connection's been established
             Thread.SpinWait(1000000000);
            
             this.Dispatcher.Invoke((Action)(() =>
             {
                 _btnOk.IsEnabled = true;
                 Cursor = Cursors.Arrow;
             }));                                
        });        
    }
