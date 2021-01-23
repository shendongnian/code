    public FloatingPanel(FrameworkElement gadget)
    {
        gridTitle = new Grid();
        gridTitle.Height = 25;
        gridTitle.Background = Brushes.Cyan;
        gridTitle.MouseLeftButtonDown += gridTitle_MouseLeftButtonDown;
        gridTitle.MouseMove += gridTitle_MouseMove;
        gridTitle.MouseLeftButtonUp += gridTitle_MouseLeftButtonUp;
        //Create two grid rows - one to hold the title bar..
        this.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
        Grid.SetRow(gridTitle, 0);
        this.Children.Add(gridTitle);
        //..and one two hold the gadget:
        this.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
        Grid.SetRow(gadget, 1);
        this.Children.Add(gadget);
    }
