    public MyUserControl()
    {
        SizeChanged += OnSizeChanged;
    }
    void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        ViewModel.ContainerWidth= e.NewSize.Width;
    }
