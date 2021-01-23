    public static readonly DependencyProperty ProgramsProperty =
           DependencyProperty.Register("Programs",
           typeof(ObservableCollection<ProgramData>), typeof(ProgramView),
           new UIPropertyMetadata(default(ObservableCollection<ProgramData>, 
           (d, e) => ((ProgramView)d).OnProgramsChanged(d, e))));
    private void OnProgramsChanged(DependencyObject dependencyObject, 
        DependencyPropertyChangedEventArgs e)
    {
        // Do something with e.OldValue and e.NewValue here
    }
