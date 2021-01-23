    public PrintWindow(PrintDocument pd)
    {
        InitializeComponents();
        this.DataContext = new PrintViewModel(pd);
    }
