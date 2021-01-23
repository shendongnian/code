    public static readonly DependencyProperty HiddenProperty = DependencyProperty.RegisterAttached(
      "IsHidden",
      typeof(bool),
      typeof(LayoutColumn)
      new PropertyMetadata(false, OnHiddenChanged));
    public static readonly DependencyProperty VisibleWidthProperty = DependencyProperty.RegisterAttached(
      "VisibleWidth",
      typeof(double),
      typeof(LayoutColumn),
      new UIPropertyMetadata(double.NaN));
    public static double GetVisibleWidth(DependencyObject obj)
    {
      return (double)obj.GetValue(VisibleWidthProperty);
    }
    public static void SetVisibleWidth(DependencyObject obj, double value)
    {
      obj.SetValue(VisibleWidthProperty, value);
    }
    private static void OnHiddenChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
      GridViewColumn column = dependencyObject as GridViewColumn;
      if (column != null)
      {
        if (e.Property == HiddenProperty)
        {
          bool hide = (bool)e.NewValue;
          if (hide)
          {
            SetVisibleWidth(column, column.Width);
            column.Width = 0;
          }
          else
          {
            column.Width = GetVisibleWidth(column);
          }
        }
      }
    }
