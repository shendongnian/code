    private void HandleLoadListClicked(object obj)
    {
        directoryName = selectedItem;
        this.Matches = DataGetterAndSetter.GetMatches("Lists\\" + directoryName + ".xml");
        MainPage window = new MainPage();
        window.Show();
    }
