	try
	{
		usersRepository.Delete(new User { Id = null });
		Assert.Fail("Deleting user with null id should throw");
	}
	catch (UserNotFoundException ue)
	{
		Assert.AreEqual(ue.InnerException.Message, "User Id must have value");
	}
