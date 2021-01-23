    	[Route("{id}")]
		public MyResponse Get(Guid? id)
		{
			if (id == null)
			{
				throw new ArgumentException("Please enter a valid Guid.");
			}
			...
		}
