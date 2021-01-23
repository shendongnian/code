	namespace UI.Controls
	{
		public class MyTextBox : TextBox
		{
			public static readonly DependencyProperty CaretPositionProperty =
				DependencyProperty.Register("CaretPosition", typeof(int), typeof(MyTextBox),
					new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnCaretPositionChanged));
			public int CaretPosition
			{
				get { return (int)GetValue(CaretPositionProperty); }
				set { SetValue(CaretPositionProperty, value); }
			}
			public MyTextBox()
			{
				SelectionChanged += (s, e) => CaretPosition = CaretIndex;
			}
			private static void OnCaretPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
			{
				(d as MyTextBox).CaretIndex = (int)e.NewValue;
			}
		}
	}
