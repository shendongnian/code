    public static DependencyProperty SomeObjectsProperty = DependencyProperty.Register("SomeObjects", typeof(ObservableCollection<Entities>), typeof(ObjectTemplate), new PropertyMetadata(new ObservableCollection<Entities>(), new PropertyChangedCallback(OnSomeObjectsPropertyChanged));
    private static void OnSomeObjectsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as ObjectTemplate).UpdateSomeObjects(e.NewValue as SomeObjects);
    }
    public void UpdateSomeObjects(SomeObjects value)
    {
        if (value != null && value.Count > 0)
        {
            foreach (SomeObject eLink in value)
            {
                //Add a new control to a wrap panel for each object in the list
            }
        }
    }
