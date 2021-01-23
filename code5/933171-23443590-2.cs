	public class CustomRectFormat : IFormatProvider, ICustomFormatter
	{
		public object GetFormat(Type formatType)
		{
			if (formatType == typeof(ICustomFormatter))
			{
				return this;
			}
			else
			{
				return null;
			}
		}
		
		// the custom format
		public string Format(string fmt, object arg, IFormatProvider formatProvider) 
		{
			// the method processes every part of the Rect members
			var chunk = arg.ToString();
			// skip delimiters
			if (chunk != ";")
			{
				// round doubles if possible
				Double part = 0.0;
				if (Double.TryParse(chunk, out part))
				{
					return Math.Round(part, 2).ToString();
				}
			}
			return chunk;
		}
	}
