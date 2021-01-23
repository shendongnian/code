    public sealed class Wedge : Shape
	{
		public Double Radius
		{
			get { return (Double)this.GetValue(RadiusProperty); }
			set { this.SetValue(RadiusProperty, value); }
		}
		public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register(
		  "Radius", typeof(Double), typeof(Wedge), new PropertyMetadata(0.0));
		protected override Geometry DefiningGeometry
		{
			get {return new EllipseGeometry(new Point(0, 0), this.Radius, this.Radius); }
		}
	}
