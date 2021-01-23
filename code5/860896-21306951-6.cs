    if (client.Connected == true)
    {
        Dispatcher.Invoke(new Action(()=> {
            // Code causing the exception or requires UI thread access
            CheckBox.IsChecked =true;
        }));
    }
