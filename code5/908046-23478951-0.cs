    // get ExtensionManager
    IVsExtensionManager manager = GetService(typeof(SVsExtensionManager)) as IVsExtensionManager;
    // get your extension by Product Id
    IInstalledExtension myExtension = manager.GetInstalledExtension("ProductId-1234-1234-1234-123456789012");
    // get current version
    Version currentVersion = myExtension.Header.Version;
