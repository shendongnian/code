    if (message.Type == WindowType.DataSourcePickerTest)
    {
        SubMethod<DataSourcePickerViewModel, PickerWindowTest>();
    }
    else if (message.Type == WindowType.BaselineSave)
    {
        SubMethod<BaselineSaveAsViewModel, BaselineSaveAs>();
    }
    public void SubMethod<T, U>() where U:WindowBase
    {
        var vm = SimpleIoc.Default.GetInstance<T>();
        var win = new U { DataContext = vm };
        var result = win.ShowDialog() ?? false;
        if (result)
            Messenger.Default.Send(vm);
    }
