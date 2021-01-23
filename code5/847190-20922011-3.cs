	//replace this class with your own implementation.
	//derive from DependencyObject and use DependencyProperty to store data
	public class BigInteger : DependencyObject
	{
		public BigInteger(int row, int col)
		{
			RowIndex = row;
			ColumnIndex = col;
		}
		//Data Dependency Property
		public string Data
		{
			get { return (string)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
		public static readonly DependencyProperty DataProperty =
			DependencyProperty.Register("Data", typeof(string), typeof(BigInteger), new UIPropertyMetadata(""));
		//RowIndex Dependency Property
		public int RowIndex
		{
			get { return (int)GetValue(RowIndexProperty); }
			set { SetValue(RowIndexProperty, value); }
		}
		public static readonly DependencyProperty RowIndexProperty =
			DependencyProperty.Register("RowIndex", typeof(int), typeof(BigInteger), new UIPropertyMetadata(0));
		//ColumnIndex Dependency Property
		public int ColumnIndex
		{
			get { return (int)GetValue(ColumnIndexProperty); }
			set { SetValue(ColumnIndexProperty, value); }
		}
		public static readonly DependencyProperty ColumnIndexProperty =
			DependencyProperty.Register("ColumnIndex", typeof(int), typeof(BigInteger), new UIPropertyMetadata(0));
	}
