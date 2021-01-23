	abstract class BaseShape : UIElement
	{
		public Polygon shape { get; protected set; }
		
		public BaseShape()
		{
			shape.Measure(new Size(length, length));
			shape.Arrange(new Rect(0, 0, length, length));
		}
		
		protected override void OnRender(DrawingContext drawingContext)
		{
			Geometry s = shape.RenderedGeometry;
			drawingContext.DrawGeometry(Brushes.Red, new Pen(Brushes.Black, 1), s);
			//base.OnRender(drawingContext);
		}
	}
	public partial class MainWindow : Window
	{
		Shapes.Square sq;
		public MainWindow()
		{
			InitializeComponent();
			sq = new Shapes.Square(50, 0, 0, 0, 0, 2, Brushes.Red, Brushes.Black, Brushes.Red, Brushes.Purple);
			canvas.Children.Add(sq);
			sq.MouseDown += test;
		}
		public void test(Object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("Testing if this works :D");
		}
	}
