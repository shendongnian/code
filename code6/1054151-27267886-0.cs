    // Register as the default handler for the tel: protocol.
    const string protocolValue = "TEL:Telephone Invocation";
    Registry.SetValue(
        @"HKEY_CLASSES_ROOT\tel",
        string.Empty,
        protocolValue,
        RegistryValueKind.String );
    Registry.SetValue(
        @"HKEY_CLASSES_ROOT\tel",
        "URL Protocol",
        String.Empty,
        RegistryValueKind.String );
    const string binaryName = "tel.exe";
    string command = string.Format( "\"{0}{1}\" \"%1\"", AppDomain.CurrentDomain.BaseDirectory, binaryName );
    Registry.SetValue( @"HKEY_CLASSES_ROOT\tel\shell\open\command", string.Empty, command, RegistryValueKind.String );
    // For Windows 8+, register as a choosable protocol handler.
    // Version detection from http://stackoverflow.com/a/17796139/259953
    Version win8Version = new Version( 6, 2, 9200, 0 );
    if( Environment.OSVersion.Platform == PlatformID.Win32NT &&
        Environment.OSVersion.Version >= win8Version ) {
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\TelProtocolHandler",
            string.Empty,
            protocolValue,
            RegistryValueKind.String );
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\TelProtocolHandler\shell\open\command",
            string.Empty,
            command,
            RegistryValueKind.String );
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SOFTWARE\TelProtocolHandler\Capabilities\URLAssociations",
            "tel",
            "TelProtocolHandler",
            RegistryValueKind.String );
        Registry.SetValue(
            @"HKEY_LOCAL_MACHINE\SOFTWARE\RegisteredApplications",
            "TelProtocolHandler",
            @"SOFTWARE\TelProtocolHandler\Capabilities",
            RegistryValueKind.String );
    }
