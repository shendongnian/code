    public bool IsSelected
    {
       get{(bool)GetValue(IsSelectedProperty)}
       set{SetValue(IsSelectedProperty, value)}
    }
    
    public static readonly DependencyProperty IsSelectedProperty = 
            DependencyProperty.Register("IsSelected", typeof(bool), type(thisCustomControlClassName), new PropertyMetadata(false, thisCustomControlClassName.IsSelectedPropertyChanged); 
    protected static void IsSelectedPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
