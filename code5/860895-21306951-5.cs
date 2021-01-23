    if (client.Connected == true)
    {
        Dispatcher.Invoke(()=> {
            // Code causing the exception or requires UI thread access
            CheckBox.IsChecked =true;
        });
    }
