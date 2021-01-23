    public class DataGridCellToRowActionParametersConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var dataGridCell = value as DataGridCell;
			if (dataGridCell == null)
			{
				return null;
			}
			var dataRowView = dataGridCell.DataContext as DataRowView;
			var columnIndex = dataGridCell.Column.DisplayIndex;
			return new RowActionParameters
			       {
					   Item = dataGridCell.DataContext,
					   ColumnPropertyName = dataGridCell.Column.SafeAccess(x => x.SortMemberPath),
					   DataRowView = dataRowView,					   
					   ColumnIndex = columnIndex
			       };
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
