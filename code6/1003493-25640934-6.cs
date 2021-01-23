    public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
    {
        var p = item.GetType().GetProperty("Value");
        
        if (t.PropertyType == typeof(DateTime))
        ...
    }
