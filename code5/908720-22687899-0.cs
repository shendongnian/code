	public static class ModelDtoComparer
	{
		public static void AssertAreEqual(Model model, Dto dto)
		{
			Assert.AreEqual(model.FKCustomerId, dto.FKCustomerId);
			Assert.AreEqual(model.Name, dto.Name);
			Assert.AreEqual(model.Description, dto.Description);
			// etc.
		}
	}
