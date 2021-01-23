        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<HttpContextBase>(
                new InjectionFactory(_ => new HttpContextWrapper(HttpContext.Current)));
            container.RegisterType<IOwinContext>(new InjectionFactory(c => c.Resolve<HttpContextBase>().GetOwinContext()));
            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => c.Resolve<IOwinContext>().Authentication));
            container.RegisterType<ILoginHandler, LoginHandler>();
            // Further registrations here...
        }
