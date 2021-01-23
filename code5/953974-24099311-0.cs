	class MyAmendment<T> : Amendment<T, T> where T : CallerClassBase
	{
		public override void Amend(Method method)
		{
			method.Before(after =>
				{
					if (after.GetType() != typeof(CallerClassBase))
					{
						// Implement your logic here
					}
				});
		}
	}
