    public static readonly DependencyProperty HiddenProperty = DependencyProperty.RegisterAttached(
      "IsHidden",
      typeof(bool),
      typeof(LayoutColumn)
      new PropertyMetadata(false, OnHiddenChanged));
    private static void OnHiddenChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
      GridViewColumn column = dependencyObject as GridViewColumn;
      if (column != null)
      {
        if (e.Property == HiddenProperty)
        {
          dependencyObject.SetCurrentValue(HiddenProperty, (bool)e.NewValue); // TODO: Not working - research this
        }
        string format = "SET: {0}.{1} = {2}";
        Console.WriteLine(format, column.Header, e.Property, e.NewValue);
      }
    }
