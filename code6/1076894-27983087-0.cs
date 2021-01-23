	public class SpreadsheetCellTemplateListing : DependencyObject
	{
		public DataTemplate structTemplate { get; set; }
		public DataTemplate atomicTemplate { get; set; }
	}
	internal class SpreadsheetDataGrid : DataGrid
	{
		private bool InitializeColumnsOnLoad = false;
		public SpreadsheetDataGrid()
		{
			Loaded += OnLoaded;
		}
		private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
		{
			if (InitializeColumnsOnLoad)
			{
				InitializeColumns();
			}
		}
		public static readonly DependencyProperty TemplateListingProperty =
			DependencyProperty.Register("TemplateListing", typeof (SpreadsheetCellTemplateListing),
				typeof (SpreadsheetCellTemplateListing), new PropertyMetadata(null));
		public SpreadsheetCellTemplateListing TemplateListing
		{
			get { return (SpreadsheetCellTemplateListing) GetValue(TemplateListingProperty); }
			set { SetValue(TemplateListingProperty, value); }
		}
		protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue,
			System.Collections.IEnumerable newValue)
		{
			base.OnItemsSourceChanged(oldValue, newValue);
			if (!IsLoaded)
			{
				InitializeColumnsOnLoad = true;
			}
			else
			{
				InitializeColumns();
			}
		}
	}
