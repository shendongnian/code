    public ObservableCollection<YourDataType> Items { get; set; }
...
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        SaveAsXml(Items);
    }
