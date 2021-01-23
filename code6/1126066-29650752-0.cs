    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
            "Value",
            typeof(object),
            typeof(DependencyPropertyWatcher),
            new PropertyMetadata(null, OnPropertyChanged));
    public event EventHandler PropertyChanged;
     public DependencyPropertyWatcher(DependencyObject target, string propertyPath)
     {
            this.Target = target;
            BindingOperations.SetBinding(
            this,
            ValueProperty,
            new Binding() { Source = target, Path = new PropertyPath(propertyPath), Mode = BindingMode.OneWay });
    }
