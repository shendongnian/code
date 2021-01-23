    public void ChangeSettings(IKernel kernel, ApplicationSettings setting)
    {
       var setting = kernel.Get<ApplicationSettings>();
       kernel.Rebind<ApplicationSettings>().ToConstant(setting);
    }
