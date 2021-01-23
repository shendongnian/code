		/// <summary>Calculate the correct precision based on trailing zeroes and target precision
		/// </summary>
		/// <param name="number">the number to check (multiply by 100 if it is being formatted as a percent)</param>
		/// <param name="trailingZeroes">the number of trailing zeroes</param>
		/// <param name="precision">the number of decimal places to show</param>
		/// <returns>
		/// Argument Exception: trailing zero and precision cannot be less than one or greater than 99
		/// Argument Exception: trailing zeros cannot be larger than the precision
		/// </returns>
		private int CalculatePrecision(double number, int trailingZeroes, int precision)
		{
			if (trailingZeroes < 0 || trailingZeroes > 99 || precision < 0 || precision > 99)
			{
				throw new ArgumentException("Trailing Zeroes and precision must be between 0 and 99.");
			}
			// make sure trailng zeroes is not larger than precision
			trailingZeroes = Math.Min(trailingZeroes, precision);
			// a temporary value for locating decimal places
			double tempValue;
			// just the decimal places
			double allDecimalPlaces = number - Math.Floor(number);
			// the individual decimal place at a given power of 10
			double singleDecimalPlaceValue;
			// search for the zeroes in the decimal places
			for (int i = precision; i > trailingZeroes; i--)
			{
				// get just the decimal place that needs to be checked
				tempValue = allDecimalPlaces * Math.Pow(10, i - 1);
				singleDecimalPlaceValue = Math.Round((tempValue - Math.Floor(tempValue)) * 10);
				// check for a 0 decimal or a 10 value (for floating point math)
				if (singleDecimalPlaceValue != 0 && singleDecimalPlaceValue != 10)
				{
					return i;
				}
			}
			// if all zeroes are found, return trailing zeroes
			return trailingZeroes;
		}
