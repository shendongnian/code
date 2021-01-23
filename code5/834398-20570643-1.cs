    public static readonly DependencyProperty DerpProperty = 
      DependencyProperty.RegisterAttached(
      "Derp",
      typeof(DependencyObject),
      typeof(Herp),
      new FrameworkPropertyMetadata());
    public static void SetDerp(DependencyObject element, Herp value)
    {
        element.SetValue(DerpProperty, value);
    }
    public static Herp GetDerp(DependencyObject element)
    {
        return (Herp)element.GetValue(DerpProperty);
    }
