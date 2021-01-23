    public class FixVirtualizedTabbingBehavior : Behavior<ListBox>
	{
		protected override void OnAttached()
		{
			AssociatedObject.PreviewKeyDown += AssociatedObjectOnPreviewKeyDown;
			AssociatedObject.GotKeyboardFocus += AssociatedObjectGotKeyboardFocus;
			base.OnAttached();
		}
		void AssociatedObjectGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			var listBox = ((ListBox)sender);
			if (e.OldFocus != null && ((DependencyObject)e.OldFocus).FindParent<ListBox>() != listBox)
			{
				var direction = Keyboard.Modifiers.HasFlag(ModifierKeys.Shift)
					? FocusNavigationDirection.Last
					: FocusNavigationDirection.First;
				MoveFocus(listBox, direction);
			}
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
				direction = FocusNavigationDirection.Previous;
			}
			else
			{
				index = listBox.Items.Count - 1;
				direction = FocusNavigationDirection.Previous;
			}
			var focusedItem = ((DependencyObject)Keyboard.FocusedElement).FindParent<ListBoxItem>();
			if (focusedItem == null || focusedItem.Content != listBox.Items[index])
			{
				return;
			}
			keyEventArgs.Handled = true;
			MoveFocus(listBox, direction);
		}
		private void MoveFocus(ListBox listBox, FocusNavigationDirection direction)
		{
			var scrollViewer = VisualTreeExtensions.FindVisualChildren<ScrollViewer>(listBox).First();
			if (direction == FocusNavigationDirection.First)
			{
				scrollViewer.ScrollToTop();
			}
			else
			{
				scrollViewer.ScrollToBottom();
			}
			Dispatcher.Invoke(new Action(() => { listBox.MoveFocus(new TraversalRequest(direction)); }),
				DispatcherPriority.ContextIdle, null);
		}
		protected override void OnDetaching()
		{
			AssociatedObject.PreviewKeyDown -= AssociatedObjectOnPreviewKeyDown;
			AssociatedObject.GotKeyboardFocus -= AssociatedObjectGotKeyboardFocus;			
			base.OnDetaching();
		}
	}
