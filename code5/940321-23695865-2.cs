    private static void CreateMemberValidationTest(MemberCreateViewModel vm, string propertyThatFails)
		{
			using (ShimsContext.Create())
			{
				// Arrange
				var mockSet = new StubDbSet<Member>();
				ShimApplicationDbContext.Constructor = (t) => { };
				ShimApplicationDbContext.AllInstances.MembersGet = (t) =>
				{
					return mockSet;
				};
				ShimDbContext.AllInstances.SaveChanges = (t) => { return 1; };
				MemberController controller = new MemberController();
				// Act
				Validate(controller, vm);
				var result = controller.Create(vm) as ViewResult;
				// Assert
				Assert.IsNotNull(result);
				Assert.AreEqual(result.ViewData.ModelState.Count, 1);
				Assert.AreEqual(result.ViewData.ModelState.Keys.First(), propertyThatFails);
			}
		}
