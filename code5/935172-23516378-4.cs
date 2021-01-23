		public class MyDataGrid : DataGrid
		{
			public void SelectManyItems(IEnumerable itemsToBeSelected)
			{
				if (!IsUpdatingSelectedItems)
				{
					BeginUpdateSelectedItems();
					foreach (object item in itemsToBeSelected)
						SelectedItems.Add(item);
					EndUpdateSelectedItems.Invoke();
				}
			}
		}
    
