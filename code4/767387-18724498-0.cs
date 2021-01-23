    		private bool CustomFilter(object item)
			{
				CheckableListItem<Item> checkableItem = item as CheckableListItem<Item>;
				if (checkableItem != null && checkableItem.Item.Name.Contains(SearchString))
				{
					return true;
				}
				return false;
			}
			private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
			{
				checkableItemsView.Filter = CustomFilter;
			}
