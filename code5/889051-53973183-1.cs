    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public async Task Account_ExistingUser_CorrectPassword(int userIndex)
    {
        // DIFFERENT INPUT DATA (static fake users on class)
        var user = new[]
        {
            EXISTING_USER_NO_MAPPING,
            EXISTING_USER_MAPPING_TO_DIFFERENT_EXISTING_USER,
            EXISTING_USER_MAPPING_TO_SAME_USER,
            NEW_USER
        } [userIndex];
        var response = await Analyze(new CreateOrLoginMsgIn
        {
            Username = user.Username,
            Password = user.Password
        });
        // expected result (using ExpectedObjects)
        new CreateOrLoginResult
        {
            AccessGrantedTo = user.Username
        }.ToExpectedObject().ShouldEqual(response);
    }
