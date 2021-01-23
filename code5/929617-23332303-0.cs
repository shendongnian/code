    public MainWindow(string data)
        : this()
    {
        coll = new ObservableCollection<string>();
        coll.Add("ABC");
        coll.Add("AAA");
        coll.Add("BBB");
        coll.Add("KKK");
        Combo.SelectedItem = coll[0];
    
        DataContext = this;
    
        coll.Add(data);  
    }
