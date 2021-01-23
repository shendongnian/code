		/// <summary>
		/// Disconnects <paramref name="child"/> from it's parent if any.
		/// </summary>
		/// <param name="child"></param>
		public static void DisconnectIt(this FrameworkElement child)
		{
			var parent = child.Parent;
			if (parent == null)
				return;
			if (parent is Panel panel)
			{
				panel.Children.Remove(child);
				return;
			}
			if (parent is Decorator decorator)
			{
				if (decorator.Child == child)
					decorator.Child = null;
				return;
			}
			if (parent is ContentPresenter contentPresenter)
			{
				if (contentPresenter.Content == child)
					contentPresenter.Content = null;
				return;
			}
			if (parent is ContentControl contentControl)
			{
				if (contentControl.Content == child)
					contentControl.Content = null;
				return;
			}
			//if (parent is ItemsControl itemsControl)
			//{
			//	itemsControl.Items.Remove(child);
			//	return;
			//}
		}
