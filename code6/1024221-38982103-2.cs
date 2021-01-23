    In my example I mocked `IdentityResult.Success` in following way:
    
    First, IdentityResult has protected constructor:
    
        protected IdentityResult(bool success);
    
    Protected constructor can be accessed from inherited class if you
    implement like this: 
    
            public class IdentityResultMock : IdentityResult
            {
                public IdentityResultMock(bool succeeded) : base(succeeded) { }
            }
    
    Second, in my unit test I configured `ResetPasswordAsync()` to
    return identityResult like in below:
    
        var identityResult = new IdentityResultMock(true);
        _mockUserManager.Setup(e => e.ResetPasswordAsync(user.Id, model.Code, model.Password)).ReturnsAsync(identityResult);
    
    Third, in my controller's action `ResetPasswordAsync()` will returns
    result with `Successed == true`:
    
        var result = await userManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
    
    Basically I implemented new class which inherited IdentityResult and
    used that in my test cases.
