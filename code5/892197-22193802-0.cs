    public class Composite : DependencyObject {
        public Composite(string str, int num){ Appearance = str; Numeric = num; }
        public string Appearance
		{
			get { return (string)GetValue(AppearanceProperty); }
			set { SetValue(AppearanceProperty, value); }
		}
		public static readonly DependencyProperty AppearanceProperty =
			DependencyProperty.Register("Appearance", typeof(string), typeof(MainWindow), new UIPropertyMetadata(null));
		public int Numeric
		{
			get { return (int)GetValue(NumericProperty); }
			set { SetValue(NumericProperty, value); }
		}
		public static readonly DependencyProperty NumericProperty =
			DependencyProperty.Register("Numeric", typeof(int), typeof(MainWindow), new UIPropertyMetadata(0));
    }
