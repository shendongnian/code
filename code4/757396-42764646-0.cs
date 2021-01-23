    var getter = typeof(MachineKeySection).GetMethod("GetApplicationConfig", BindingFlags.Static | BindingFlags.NonPublic);
    var config = (MachineKeySection)getter.Invoke(null, Array.Empty<object>());
    var readOnlyField = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
    readOnlyField.SetValue(config, false);
    config.DecryptionKey = myKeys.EncryptionKey;
    config.ValidationKey = myKeys.ValidationKey;
    readOnlyField.SetValue(config, true);
