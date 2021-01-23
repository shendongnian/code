	namespace behaviors
    {
		using System.Windows;
		using System.Windows.Controls;
		using System.Windows.Interactivity;
		using System.Windows.Media;
		public class ListBoxItemIsVisibleBehavior : Behavior<ListBoxItem>
		{
			public static readonly DependencyProperty IsInViewportProperty = DependencyProperty.RegisterAttached("IsInViewport", typeof(bool), typeof(ListBoxItemIsVisibleBehavior));
			public static bool GetIsInViewport(UIElement element)
			{
				return (bool)element.GetValue(IsInViewportProperty);
			}
			public static void SetIsInViewport(UIElement element, bool value)
			{
				element.SetValue(IsInViewportProperty, value);
			}
			protected override void OnAttached()
			{
				base.OnAttached();
				try
				{
					this.AssociatedObject.LayoutUpdated += this.AssociatedObject_LayoutUpdated;
				}
				catch { }
			}
			protected override void OnDetaching()
			{
				try
				{
					this.AssociatedObject.LayoutUpdated -= this.AssociatedObject_LayoutUpdated;
				}
				catch { }
				base.OnDetaching();
			}
			private void AssociatedObject_LayoutUpdated(object sender, System.EventArgs e)
			{
				if (this.AssociatedObject.IsVisible == false)
				{
					SetIsInViewport(this.AssociatedObject, false);
					return;
				}
				var container = WpfExtensions.FindParent<ListBox>(this.AssociatedObject);
				if (container == null)
				{
					return;
				}
				var visible = this.IsVisibleToUser(this.AssociatedObject, container) == true;
				SetIsInViewport(this.AssociatedObject, visible);
			}
			private bool IsVisibleToUser(FrameworkElement element, FrameworkElement container)
			{
				if (element.IsVisible == false)
				{
					return false;
				}
				GeneralTransform transform = element.TransformToAncestor(container);
				Rect bounds = transform.TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
				Rect viewport = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
				return viewport.IntersectsWith(bounds);
			}
		}
    }
