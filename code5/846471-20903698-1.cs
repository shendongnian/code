        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUsers>().To<UsersService>();
            kernel.Bind<IRoles>().To<RolesService>();
            kernel.Bind<MembershipProvider>().To<AccountMembershipProvider>().InRequestScope();
            kernel.Bind<RoleProvider>().To<AccountRoleProvider>().InRequestScope();
        }
