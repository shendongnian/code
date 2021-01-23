	public partial class demo_listview : ListView
	{
		protected override void ClearContainerForItemOverride(DependencyObject el, object item)
		{
			base.ClearContainerForItemOverride(el, item);
			var lvi = (ListViewItem)el;
			var gv_row = (GridViewRowPresenter)lvi.Template.FindName("5_T", lvi);
			var ix = ((GridView)View).Columns.IndexOf(my_gv_column);
			var cp = (ContentPresenter)VisualTreeHelper.GetChild(gv_row, ix);
			var tb = (TextBlock)my_gv_column.CellTemplate.FindName("my_textblock", cp);
			tb.Background = Brushes.Red;
		}
	};
