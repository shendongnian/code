    [TestMethod]
    public async Task can_update_user_details()
    {
        //Arrange
        var user = await _repository.Object.FindByIdAsync("70a038cdde40");
        Assert.IsFalse(user.EmailConfirmed, "User.EmailConfirmed is True");
        //Act            
        user.EmailConfirmed = true;
        await _repository.Object.UpdateAsync(user);
        var newUser = await _repository.Object.FindByIdAsync("70a038cdde40");
        //Assert
        Assert.IsTrue(newUser.EmailConfirmed, "User.EmailConfirmed is False");
    }
