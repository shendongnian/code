    private void timerCallback(Object state)
    {
       for (int i = 0; i < 64; i++)
           AddElement(this.dataGridFiles, new DataFile("A", "B", "C", "D"));
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.timer = new System.Threading.Timer(this.timerCallback, true, 1000, System.Threading.Timeout.Infinite);
    }
    delegate void AddElementDelegateType(DataGrid dg, DataFile df);
    AddElementDelegateType AddElementDelegate = (a, b) => ((ObservableCollection<DataFile>)(a.ItemsSource)).Add(b);
    private void AddElement(DataGrid dg, DataFile df)
    {
        if (!dg.Dispatcher.CheckAccess())
        {
            Action<DataGrid, DataFile> act = new Action<DataGrid, DataFile>((a, b) => AddElement(a, b));
            dg.Dispatcher.Invoke(act, new object[] { dg, df });
        }
        else
            ((ObservableCollection<DataFile>)(dg.ItemsSource)).Add(df);
    }
