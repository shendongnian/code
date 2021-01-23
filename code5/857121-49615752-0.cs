    public class FakeUserManager : UserManager<User>
        {
            public FakeUserManager() 
                : base(new Mock<IUserStore<User>>().Object,
                      new Mock<IOptions<IdentityOptions>>().Object,
                      new Mock<IPasswordHasher<User>>().Object,
                      new IUserValidator<User>[0],
                      new IPasswordValidator<User>[0],
                      new Mock<ILookupNormalizer>().Object, 
                      new Mock<IdentityErrorDescriber>().Object,
                      new Mock<IServiceProvider>().Object,
                      new Mock<ILogger<UserManager<User>>>().Object, 
                      new Mock<IHttpContextAccessor>().Object)
            { }
    
            public override Task<User> FindByEmailAsync(string email)
            {
                return Task.FromResult(new User{Email = email});
            }
    
            public override Task<bool> IsEmailConfirmedAsync(User user)
            {
                return Task.FromResult(user.Email == "test@test.com");
            }
    
            public override Task<string> GeneratePasswordResetTokenAsync(User user)
            {
                return Task.FromResult("---------------");
            }
        }
