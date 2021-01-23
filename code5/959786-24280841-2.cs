    public void CreateAccount_WhenCalledLikeThis_DoesSomeCoolStuff()
    {
         var accountRepoMock = new Mock<AccountRepository>();
         // set it up
         var billingRepository = new Mock<BillingRepository>();
         // set it up
         var appService = new ApplicationService(accountRepoMock.Object, billingRepoMock.Objcet);
    
         // More setup
    
         // Act
         var response = appService.CreateAccount(...);
    
         // Assert on response and/or verify mocks
    }
