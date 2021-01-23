    public static InstallationType GetInstallationType() {
       /* your logic goes here */
    }
    // Bindings
    IBindingRoot.Bind<BaseInstallation>().To<InstallationTablet>()
                .When(ctx => GetInstallationType() == InstallationType.Tablet);
    IBindingRoot.Bind<BaseInstallation>().To<InstallationFull>()
                .When(ctx => GetInstallationType() == InstallationType.Full);
