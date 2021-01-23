    public static readonly DependencyProperty WeightProperty = DependencyProperty.RegisterAttached(
      "Weight",
      typeof(double),
      typeof(HelperClass),
      new FrameworkPropertyMetadata(0)
    );
    public static void SetWeight(Ellipse element, double value){
      element.SetValue(WeightProperty, value);
    }
    public static double GetWeight(Ellipse element) {
      return (double)element.GetValue(WeightProperty);
    }
