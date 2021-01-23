    try
    {
        DataBaseIkuns.Instance.OpenConnectionWithDB();
        DataBaseIkuns.Instance.LoadDataFromDB(/* ... */);
                
        var view = DataBaseIkuns.Instance.dt.DefaultView;
        dataGridIkuns.ItemsSource = view;
        dataGridIkuns.Dispatcher.BeginInvoke(
            DispatcherPriority.Loaded,
            new Action(
                () =>
                {
                    if (dataGridIkuns.ItemsSource == view)
                        SetNameOnHeaderColumn(dataGridIkuns);
                }));
                
        DataBaseIkuns.Instance.CloseConnectionWithDB();
    }
    catch (Exception ex)
    {
        System.Windows.Forms.MessageBox.Show(ex.ToString());
    }
