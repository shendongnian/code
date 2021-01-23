		/// <summary>
		/// Calculates the age at the specified date.
		/// </summary>
		/// <param name="dateOfBirth">The date of birth.</param>
		/// <param name="referenceDate">The date for which the age should be calculated.</param>
		/// <returns></returns>
		public static int Age(DateTime dateOfBirth, DateTime referenceDate)
		{
			int years = referenceDate.Year - dateOfBirth.Year;
			dateOfBirth = dateOfBirth.AddYears(years);
			if (dateOfBirth.Date > referenceDate.Date)
				years--;
			return years;
		}
		/// <summary>
		/// Calculates the age at this moment.
		/// </summary>
		/// <param name="dateOfBirth">The date of birth.</param>
		/// <returns></returns>
		public static int Age(DateTime dateOfBirth)
		{
			return Age(dateOfBirth, DateTime.Today);
		}
