    private ObservableCollection<SomeClass> _passedlist;
    // 
    public YourOtherWindow(ObservableCollection<SomeClass> passedlist) {
     _passedlist = passedlist;
    }
    private void YourAddMethod() {
        // sadly this doesnt work so will with tuples
        // you will need SomeClass to be a class you create an instance of
        var x = new SomeClass();
        // set data on x as appropiate
        // this triggers wpf to update the mainwindow list, without reloading the window
        _passedlist.add(x);
    }
