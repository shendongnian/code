	/// <summary>
	/// Break a data row into a collection of strings based on the expected column widths.
	/// </summary>
	/// <param name="input">The width delimited input data to break into sub strings.</param>
	/// <returns>
	/// An empty collection if the input string is empty or a comment.
	/// A collection of the width delimited values contained in the input string otherwise.
	/// </returns>
	private static IEnumerable<string> ParseRow(string input) {
		const string COMMENT_PREFIX = "COM*";
		var columnWidths = new int[] { 3, 2, 2, 3, 6, 14, 2, 2, 3, 2, 2, 10, 7, 7, 2, 1, 1, 2, 7, 1, 1 };
		int inputCursor = 0;
		int columnIndex = 0;
		var parsedValues = new List<string>();
		if (String.IsNullOrEmpty(input) || input.StartsWith(COMMENT_PREFIX) || input.Trim().Length == 0) {
			return parsedValues;
		}
		while (inputCursor < input.Length && columnIndex < columnWidths.Length) {
			//Make sure the column width never exceeds the bounds of the input string. This can happen if the input string doesn't end on the edge of a column.
			int columnWidth = Math.Min(columnWidths[columnIndex++], input.Length - inputCursor);
			string columnValue = input.Substring(inputCursor, columnWidth);
			parsedValues.Add(columnValue);
			inputCursor += columnWidth;
		}
		return parsedValues;
	}
