    public class MyControl:UserControl 
    {
      public MyControl() : base() { }
      public double ZoomPercentage
      {
        get { return (double)this.GetValue(ZoomPercentageProperty); }
        set { this.SetValue(ZoomPercentageProperty, value); } 
      }
      public static readonly DependencyProperty ZoomPercentageProperty = DependencyProperty.Register(
        "ZoomPercentage", typeof(double), typeof(MyControl:),new PropertyMetadata(0));
    }
