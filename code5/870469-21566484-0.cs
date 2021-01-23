    public static readonly DependencyProperty DataSourceProperty = 
        DependencyProperty.Register("DataSource", typeof(object), typeof(MyControl), new PropertyMetaData(OnDataSourceChanged));
    
    private static void OnDataSourceChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        var newValue = e.NewValue;
        
        if(newValue == null)
            return;
        
        var asSingleLevel = newValue as ObservableCollection<MyCustomType>;
        if(asSingleLevel != null)
        {
            // Do work for single level
        }
        else
        {
            var asDoubleLevel = newValue as ObservableCollection<ObservableCollection<MyCustomType>>;
            
            if(asDoubleLevel != null)
            {
                // Do work for double level
            }
        }
    }
