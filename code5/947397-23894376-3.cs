        // Match any filename (unless you have a way of getting _fakeUserJsonFile into the SUT)
        // Match any list, as long as it contains the new user
        _jsonService.SerializeObject(Arg.Any<string>(), Arg.Is<List<User>>(list => list.Contains(_fakeNewUser))).Returns(true);
        //When
        var result = _userService.AddUser(_fakeNewUser);
        //Then
        Assert.IsTrue(result); // Only returns true if the mock object is invoked as expected
        // There is no way to verify the following assertion, because the test has no way of accessing the "updated" list
        //Assert.Contains(_fakeNewUser, _fakeUserList);
