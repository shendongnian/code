	public static class TestableDbFunctions
	{
		[System.Data.Entity.DbFunction("Edm", "DiffHours")]
		public static int? DiffHours(DateTime? dateValue1, DateTime? dateValue2)
		{
			if (!dateValue1.HasValue || !dateValue2.HasValue)
				return null;
			return (int)((dateValue2.Value - dateValue1.Value).TotalHours);
		}
	}
