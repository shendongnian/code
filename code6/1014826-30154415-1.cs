	[TestMethod]
	public void TestGetAllUsers()
	{
		//Arrange
		var mock = new Mock<IDbContext>();
		mock.Setup(x => x.Set<User>())
			.Returns(new FakeDbSet<User>
			{
				new User { ID = 1 }
			});
		UserService userService = new UserService(mock.Object);
		// Act
		var allUsers = userService.GetAllUsers();
		// Assert
		Assert.AreEqual(1, allUsers.Count());
	}
