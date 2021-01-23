	public static class Helpers
	{
		public static bool GetClassNames(int page, int totalPages, int currentPage)
		{
			var classNames = new List<string>();
		
			var isWithinFirstOrLastThree = page <= 2 || page >= (totalPages - 2);
		
			if (isWithinFirstOrLastThree)
			{
				classNames.Add("disabled");
			}
			if (page == currentPage)
			{
				classNames.Add("active");
			}
		
			return string.Join(" ", classNames.ToArray());
		}
	}
