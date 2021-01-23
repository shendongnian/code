    public class FixVirtualizedTabbingBehavior : Behavior<ListBox>
	{
		protected override void OnAttached()
		{
			AssociatedObject.PreviewKeyDown += AssociatedObjectOnPreviewKeyDown;
			base.OnAttached();
		}
		private void AssociatedObjectOnPreviewKeyDown(object sender, KeyEventArgs keyEventArgs)
		{
			if (keyEventArgs.Key != Key.Tab)
			{
				return;
			}
			var listBox = ((ListBox)sender);
			int index;
			FocusNavigationDirection direction;
			if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
			{
				index = 0;
				direction = FocusNavigationDirection.Last;
			}
			else
			{
				index = listBox.Items.Count - 1;
				direction = FocusNavigationDirection.First;
			}
			var focusedItem = ((DependencyObject) Keyboard.FocusedElement).FindParent<ListBoxItem>();
			if (focusedItem == null || focusedItem.Content != listBox.Items[index])
			{
				return;
			}
			keyEventArgs.Handled = true;
			var scrollViewer = VisualTreeExtensions.FindVisualChildren<ScrollViewer>(listBox).First();
			if (direction == FocusNavigationDirection.First)
			{
				scrollViewer.ScrollToTop();
			}
			else
			{
				scrollViewer.ScrollToBottom();
			}
			Dispatcher.Invoke(new Action(() =>
			{
				listBox.MoveFocus(new TraversalRequest(direction));
			}), DispatcherPriority.ContextIdle, null);
		}
		protected override void OnDetaching()
		{
			AssociatedObject.PreviewKeyDown -= AssociatedObjectOnPreviewKeyDown;			
			base.OnDetaching();
		}
	}
