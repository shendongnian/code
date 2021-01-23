    public MainWindow()
    {
        MyViewModel myOnlyViewModel = new MyViewModel();
        View1 view1 = new View1(myOnlyViewModel);
        view1.Show();
        View2 view2 = new View2(myOnlyViewModel);
        view2.Show();
        View3 view3 = new View3(myOnlyViewModel);
        view3.Show();
    }
