    public static class Extensions
	{
		public class Table<Column, Row>
		{
			public List<Column> Columns;
			public List<Row> Rows;
			public List<List<int>> Cells;
			public List<int> ColTotals;
			public List<int> RowTotals;
		}
		private static List<P> GetValues<T, P>(IEnumerable<T> source, Func<T, P> selector)
		{
			return source.Select(selector).OrderBy(x => x).Distinct().ToList();
		}
		public static Table<Column, Row> ToTable<T, Column, Row>(this IEnumerable<T> source, Func<T, Column> columnSelector, Func<T, Row> rowSelector)
		{
			var cols = GetValues(source, columnSelector);
			var rows = GetValues(source, rowSelector);
			var cells = rows.Select(r => cols.Select(c => source.Count(x => columnSelector(x).Equals(c) && rowSelector(x).Equals(r))).ToList()).ToList();
			return new Table<Column, Row>() 
				{
					Columns = cols,
					Rows = rows,
					Cells = cells,
					ColTotals = cols.Select((x, i) => cells.Sum(c => c[i])).ToList(),
					RowTotals = cells.Select(x => x.Sum()).ToList(),
				};
		}
	}
