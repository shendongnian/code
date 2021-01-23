        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        mock.Setup(m => m.roleRepository.Get(It.IsAny<int>()))
            .Returns(new[]{
               new Role
               {
                 Id=1, 
                 RoleName="Admin", 
                 Users = new List<User>
                  {
                     new User 
                     { 
                       // Set SomeUserProperties Here 
                     },
                     // Add another User here if needed
                  }},
               new Role
               {
                   Id=2,
                   RoleName="User" 
                   // Add users here
               }
              }
             );
