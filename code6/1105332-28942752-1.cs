    [Test]
        public void Account_UnlicensedCustomerIdentity_IsStudioLicenseAndIshavinglicenseFalse()
        {
          //Arrange
          // using Moq
          //var mock = new Mock<IPlatformProductProvider>();
          //IPlatformProductProvider provider = mock.Object;
          //provider.Filepath = "pippo.xml";
          // otherwise
                var provider = new PlatformProductProvider("pippo.xml");
          
          //Act
          NugetPlatformModel nugetPlatformModel = new NugetPlatformModel(provider);
    
          //Assert
          AssertEquals(false, nugetPlatformModel.IsHavingLicense);
    
        }
