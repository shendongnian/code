    private Func<IContext, object> RetrieveInRequestScopeCallback()
    {
        using (var kernel = new StandardKernel())
        {
            kernel.Bind<object>().ToSelf().InRequestScope();
            return kernel.GetBindings(typeof(object)).Single().ScopeCallback;
        }
    }
