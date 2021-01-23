    public MyView()
    {
        InitializeComonent
        Loaded += (sender, args) => ((MyViewModel)DataContext).GetSelectedItems = () => grid.Selecteditems;
    }
