	public class TypeCount {
		public int IntCount;
		public int LongCount;
		public int DoubleCount;
		public int DecimalCount;
		public int DateCount;
		// etc;
		// provide your own logic to determine the best type
		public Type BestType {
			get {
				int[] counts = new int[] { IntCount, LongCount, DoubleCount, DecimalCount, DateCount };
				Type[] types = new Type[] { typeof(int), typeof(long), typeof(double), typeof(decimal), typeof(DateTime) };
				Type bt = typeof(String);
				int max = 0;
				for (int i = 0; i < counts.Length; i++) {
					if (counts[i] > max) {
						bt = types[i];
						max = counts[i];
					}
				}
				return bt;
			}
		}
	}
	public static void TryParse(String s, NumberStyles ns, DateTimeStyles dts, IFormatProvider fp, String[] dateFormats, TypeCount counts) {
		if (String.IsNullOrEmpty(s))
			return;
		long l;
		int i;
		double d;
		decimal m;
		// could test byte and short too if needed
		if (int.TryParse(s, ns, fp, out i)) {
			counts.IntCount++;
			counts.LongCount++; // if int parses, then long also parses
		}
		else if (long.TryParse(s, ns, fp, out l))
			counts.LongCount++;
		// etc.
		foreach (String f in dateFormats) {
			DateTime date;
			if (DateTime.TryParseExact(s, f, fp, dts, out date))
				counts.DateCount++;
		}
	}
	public static void ConvertColumns(DataTable table) {
		IFormatProvider fp = CultureInfo.InvariantCulture;
		NumberStyles ns = NumberStyles.Any;
		DateTimeStyles dts = DateTimeStyles.None;
		String[] dateFormats = new String[] { "yyyy-MM-dd", "MM/dd/yyyy" };
		for (int i = 0; i < table.Columns.Count; i++) {
			DataColumn col = table.Columns[i];
			if (col.DataType != typeof(String))
				continue;
			TypeCount counts = new TypeCount();
			for (int j = 0; j < table.Rows.Count; j++) {
				String s = table.Rows[j][col] as String;
				TryParse(s, ns, dts, fp, dateFormats, counts);
			}
			Type bestType = counts.BestType;
			DataColumn temp = null;
			if (bestType == typeof(int)) {
				temp = table.Columns.Add("temp", typeof(int));
				for (int j = 0; j < table.Rows.Count; j++) {
					int val = 0;
					String s = table.Rows[j][col] as String;
					if (int.TryParse(s, ns, fp, out val))
						table.Rows[j][temp] = val;
				}
			}
			//else if (bestType == ...) {}
			if (temp != null) {
				temp.SetOrdinal(col.Ordinal);
				table.Columns.Remove(col);
				temp.ColumnName = col.ColumnName;
			}
		}
	}
