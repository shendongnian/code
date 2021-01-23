    // Register the viewer types
    var viewers = new UnityContainer();
    viewers
       .RegisterType<IViewer, Webwiewer>(".jpeg")
       .RegisterType<IViewer, Docviewer>(".doc");
    // Get a viewer
    var viewer = viewers.Resolve<IViewer>(ext);
