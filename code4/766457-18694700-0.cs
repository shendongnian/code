    public ObservableCollection<Member>  ComboBoxSource;
    public UpdateComboBoxContents()
    {
        List<Member> newList;
        // Omitted Code to retrieve list from datasource..
        ComboBoxSource = new ObservableCollection<Member>(newList);        
        // I’ve also tried..
        OnPropertyChanged("ComboBoxSource");
    }
    <ComboBox Name="myComboBox" SelectedValuePath="PublicID"
    DisplayMemberPath="Description" ItemsSource="{Binding ComboBoxSource,
    UpdateSourceTrigger=PropertyChanged}"/>
