            For<ISecureDataFormat<AuthenticationTicket>>().Use<SecureDataFormat<AuthenticationTicket>>();
            For<IDataSerializer<AuthenticationTicket>>().Use<TicketSerializer>();
            For<IDataProtector>().Use(() => new DpapiDataProtectionProvider().Create("ASP.NET Identity"));
            For<ITextEncoder>().Use<Base64UrlTextEncoder>();
            For<Microsoft.AspNet.Identity.IUserStore<ApplicationUser>>().Use<Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>>();
            For<System.Data.Entity.DbContext>().Use(() => new ApplicationDbContext());
