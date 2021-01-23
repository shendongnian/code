    [TestMethod]
		public void CreateMemberSucceededTest()
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
				MemberCreateViewModel vm = new MemberCreateViewModel()
				{
					Addition = "A",
					BirthDay = new DateTime(1995, 10, 14),
					City = "Rotterdam",
					Email = "test.user@fake.com",
					FirstName = "Test",
					HouseNumber = 4,
					LastName = "Persoon",
					MemberSince = new DateTime(2007, 10, 8),
					MobileNumber = "1234567890",
					PhoneNumber = "1234567890",
					Street = "Staartmanslaan",
					ZipCode = "3134kl"
				};
				// Act
				Validate(controller, vm);
				var result = controller.Create(vm) as RedirectToRouteResult;
				
				// Assert
				Assert.IsNotNull(result);
				Assert.AreEqual(result.RouteValues["action"], "Index");
			}
		}
