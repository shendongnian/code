	class myspread : FarPoint.Win.Spread.FpSpread,
		IEnumerable<FarPoint.Win.Spread.Row>
	{
		public IEnumerable<FarPoint.Win.Spread.Row> GetEnumerator()
		{
			var rows = ActiveSheet.Rows;
			for (int i = 0; i < rows.Count; ++i)
				yield return rows.Item[i];
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
