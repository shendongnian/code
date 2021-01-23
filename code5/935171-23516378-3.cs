	public static class MultiSelectorHelper
	{
		private static readonly PropertyInfo _piIsUpdatingSelectedItems;
		private static readonly MethodInfo _miBeginUpdateSelectedItems;
		private static readonly MethodInfo _miEndUpdateSelectedItems;
		static MultiSelectorHelper()
		{
			_piIsUpdatingSelectedItems = typeof(MultiSelector).GetProperty("IsUpdatingSelectedItems", BindingFlags.NonPublic | BindingFlags.Instance);
			_miBeginUpdateSelectedItems = typeof(MultiSelector).GetMethod("BeginUpdateSelectedItems", BindingFlags.NonPublic | BindingFlags.Instance);
			_miEndUpdateSelectedItems = typeof(MultiSelector).GetMethod("EndUpdateSelectedItems", BindingFlags.NonPublic | BindingFlags.Instance);
		}
		public static void SelectManyItems(this MultiSelector control, IEnumerable itemsToBeSelected)
		{
			control.Dispatcher.Invoke(
				(Action) (() =>
				{
					if ((bool) _piIsUpdatingSelectedItems.GetValue(control, null))
					{
						// That should not happen, as this code now runs in the
						// control dispatcher thread. But if it does, then throw
						// an exception, or do some other error handling appropriate
						// for your software.
					}
					_miBeginUpdateSelectedItems.Invoke(control, null);
					foreach (object item in itemsToBeSelected)
						control.SelectedItems.Add(item);
					_miEndUpdateSelectedItems.Invoke(control, null);
				})
			);
		}
	}
