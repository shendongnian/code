    RegistryKey packageKey = Registry.ClassesRoot.OpenSubKey(@"ActivatableClasses\Package");
    appKey = packageKey.OpenSubKey(packageKey.GetSubKeyNames().First(x => x.StartsWith(appName)));
    var serverNameKey = appKey.OpenSubKey(@"ActivatableClassId\App");
    var serverName = (string)serverNameKey.GetValue("Server");
    var serverKey = appKey.OpenSubKey("Server\\" + serverName);
    var AppUserModelId = (string)serverKey.GetValue("AppUserModelId");
