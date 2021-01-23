     private void UnityRegister(IUnityContainer container)
     {
        container.RegisterType<HttpContextBase>(new OnDemandInjectionFactory<HttpContextBase>(c => new HttpContextWrapper(HttpContext.Current)));
        container.RegisterType<HttpRequestBase>(new OnDemandInjectionFactory<HttpRequestBase>(c => new HttpRequestWrapper(HttpContext.Current.Request)));
        container.RegisterType<HttpSessionStateBase>(new OnDemandInjectionFactory<HttpSessionStateBase>(c => new HttpSessionStateWrapper(HttpContext.Current.Session)));
        container.RegisterType<HttpServerUtilityBase>(new OnDemandInjectionFactory<HttpServerUtilityBase>(c => new HttpServerUtilityWrapper(HttpContext.Current.Server)));
     }
