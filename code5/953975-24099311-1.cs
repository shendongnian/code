	class MyAmendment<T> : Amendment<T, T> where T : CallerClassBase
	{
		public override void Amend(Method method)
		{
			method.Before(amended =>
				{
					if (amended.GetType() != typeof(CallerClassBase))
					{
						// Implement your logic here
					}
				});
		}
	}
