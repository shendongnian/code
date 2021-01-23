    if (client.Connected == true)
    {
        Dispatcher.Invoke(()=>{
            CheckBox.IsChecked =true;
        });
    }
