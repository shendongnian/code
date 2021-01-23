    public static Mock<RoleManager<ApplicationRole>> GetMockRoleManager()
    {
       var roleStore = new Mock<IRoleStore<ApplicationRole>>();
       return new Mock<RoleManager<ApplicationRole>>(
                    roleStore.Object,null,null,null,null);
                
    }
