	[TestMethod]
	public void TestCurrentYear()
	{
		int fixedYear = 2000;
		// Shims can be used only in a ShimsContext:
		using (ShimsContext.Create())
		{
			// Arrange:
			// Shim DateTime.Now to return a fixed date:
			System.Fakes.ShimDateTime.NowGet =  
			() =>
			{ return new DateTime(fixedYear, 1, 1); };
			// Act:
			int year = DateTime.Now.Year;
			// Assert: 
			Assert.AreEqual(fixedYear, year);
		}
	}
