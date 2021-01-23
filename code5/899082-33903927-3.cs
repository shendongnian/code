    public sealed partial class MyCustomControl : UserControl
    {
	public double ProgressValue
	{
		get { return (double)GetValue(ProgressValueProperty); }
		set { SetValue(ProgressValueProperty, value); }
	}
	// Using a DependencyProperty as the backing store for ProgressValue.  This enables animation, styling, binding, etc...
	public static readonly DependencyProperty ProgressValueProperty =
		DependencyProperty.Register("ProgressValue", typeof(double), typeof(MyCustomControl), new PropertyMetadata(0.0, OnProgressValueChanged));
	private static void OnProgressValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//throw new NotImplementedException();
		MyCustomControl circularProgressBar = d as MyCustomControl;
		if (circularProgressBar != null)
		{
			double r = 19;
			double x0 = 20;
			double y0 = 20;
			circularProgressBar.myArc.Size = new Size(19, 19);
			double angle = 90 - (double)e.NewValue / 100 * 360;
			double radAngle = angle * (PI / 180);
			double x = x0 + r * Cos(radAngle);
			double y = y0 - r * Sin(radAngle);
			
			if (circularProgressBar.myArc != null)
			{
				circularProgressBar.myArc.IsLargeArc = ((double)e.NewValue >= 50);
				circularProgressBar.myArc.Point = new Point(x, y);
			}
		}
	}
	public MyCustomControl()
	{
		this.InitializeComponent();
	}
