    ObservableCollection<DateTime> myDateTimeCollection = new ObservableCollection<DateTime>();
    myDateTimeCollection.Add(DateTime.Now); // add more members
    
    myComboBox.ItemsSource = myDateTimeCollection;
    DateTime selectedDateTime = (DateTime)myComboBox.SelectedItem; //add this in myComboBox_SelectionChanged event
