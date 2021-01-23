    container.Register(
    Classes
        .FromAssemblyNamed("MyProject.Web").Where(t => t.FullName == "MyProject.Web.Modules.AuthenticationModule").
        .BasedOn<IBaseHttpModule>()
        .LifestylePerWebRequest()
