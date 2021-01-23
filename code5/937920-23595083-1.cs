    private void HandleLoadListClicked(object obj)
    {
        directoryName = selectedItem;
        matches = DataGetterAndSetter.GetMatches("Lists\\" + directoryName + ".xml");
        MainPage window = new MainPage();
        window.Show();
        this.PropertyChanged(this, propertyChangedEventArgs);
    }
