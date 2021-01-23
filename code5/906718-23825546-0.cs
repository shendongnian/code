	public class CustomLabelProvider : LabelProviderBase
	{
		/// <summary>Formats a label for the axis from the specified data-value passed in</summary>
		/// <param name="dataValue">The data-value to format</param>
		/// <returns>The formatted label string</returns>
		public override string FormatLabel(IComparable dataValue)
		{
			return dataValue.ToString(); // TODO: Implement as you wish
		}
		/// <summary>Formats a label for the cursor, from the specified data-value passed in</summary>
		/// <param name="dataValue">The data-value to format</param>
		/// <returns>The formatted cursor label string</returns>
		public override string FormatCursorLabel(IComparable dataValue)
		{
			return dataValue.ToString();// TODO: Implement as you wish
		}
	}
