    [TestMethod]
    public void CanOnlyGetCurrentLinkedUsers()
    {
		using (ShimsContext.Create())
		{
            System.Data.Entity.Fakes.ShimDbFunctions.TruncateTimeNullableOfDateTime =
				(DateTime? input) =>
				{
					return input.HasValue ? (DateTime?)input.Value.Date : null;
				};
		
			var up = new List<par_UserPlacement>
			{
				this.UserPlacementFactory(1, 2, 1), // Create a user placement that is current
				this.UserPlacementFactory(1, 3, 2, false) // Create a user placement that is not current
			}.AsQueryable();
			var set = DLTestHelper.GetMockSet<par_UserPlacement>(up);
			var context = DLTestHelper.Context;
			context.Setup(c => c.par_UserPlacement).Returns(set.Object);
			var getter = DLTestHelper.New<LinqUserGetLinkedUsersForParentUser>(context.Object);
			var output = getter.GetLinkedUsers(1);
		}
        var users = new List<User>();
        output.ProcessDataTable((DataRow row) => users.Add(new User(row)));
        Assert.AreEqual(1, users.Count);
        Assert.AreEqual(2, users[0].UserId);
    }
