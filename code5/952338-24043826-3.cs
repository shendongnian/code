    public MainPage()
    {
        this.InitializeComponent();
        myPivot.IsHitTestVisible = false; // disable the Pivot 
        LayoutRoot.ManipulationMode = ManipulationModes.TranslateX;
        LayoutRoot.ManipulationCompleted+=LayoutRoot_ManipulationCompleted;
    }
    private void LayoutRoot_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
    {
        var velocity = e.Velocities;
        if (velocity.Linear.X < 0) // swipe to the left
        {
            if (myPivot.SelectedIndex < myPivot.Items.Count - 1) myPivot.SelectedIndex++;
            else myPivot.SelectedIndex = 0;
        }
        else if (myPivot.SelectedIndex > 0) myPivot.SelectedIndex--; // to the right
        else myPivot.SelectedIndex = myPivot.Items.Count - 1;
    }
