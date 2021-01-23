    // Register the viewer types
    var viewers = = new UnityContainer();
    viewers.RegisterType<IViewer, WebViewer>(".jpeg");
    // Get a viewer
    var viewer = viewers.Resolve<IViewer>(ext);
