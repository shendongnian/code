	public class OnMouseOver : DependencyObject
	{
		public static readonly DependencyProperty BackgroundProperty =
		DependencyProperty.RegisterAttached(
		  "Background",
		  typeof(Brush),
		  typeof(OnMouseOver)
		);
		public static void SetBackground(UIElement element, Brush value)
		{
			element.SetValue(BackgroundProperty, value);
		}
		public static Brush GetBackground(UIElement element)
		{
			return (Brush)element.GetValue(BackgroundProperty);
		}
	}
