    if (client.Connected == true)
    {
        Dispatcher.Invoke(new Action(()=>{
            CheckBox.IsChecked =true;
        }));
    }
