    [Fact]
    public void Add_User_To_User_List()
    {
        //Given
        _userService = new UserService(_jsonService, _guidService);
        _jsonService = Substitute.For<IJsonService>();
        var _fakeUserJsonFile = "Users.json";
        var _fakeNewUser = new User()
        {
            ID = new Guid(),
            FirstName = "Denis",
            LastName = "Menis"
        };
        var _fakeUserList = new List<User>
        {
            new User()
                {
                    ID = new Guid(),
                    FirstName = "Paddy",
                    LastName = "Halle"
                },
            new User()
                {
                    ID = new Guid(),
                    FirstName = "Job",
                    LastName = "Blogs"
                }
        };
        _jsonService.DeserializeObject<User>(_fakeUserJsonFile).Returns(_fakeUserList);
        _jsonService.SerializeObject(_fakeUserJsonFile, _fakeUserList).Returns(true); // Match the original _fakeUserList, since that is what gets passed in by the implementation
        //When
        var result = _userService.AddUser(_fakeNewUser);
        //Then
        Assert.Contains(_fakeNewUser, _fakeUserList); // Verify that the provided _fakeUserList has been modified
    }
