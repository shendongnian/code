    var dataContext = new PersonEntryViewModel();
    this.ContentPanel.DataContext = dataContext.CurrentPerson;
    // After creating App bar
    this.appBar.DataContext = dataContext;
    //Your xaml code will look something like this:
    <AppBar x:Name="appBar">
        <Button x:Name="saveBtn" IsEnabled={Binding EnableSaveButton} />
    <AppBar />
