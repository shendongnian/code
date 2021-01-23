    foreach (string regItem in Enum.GetNames(typeof(RegistryRights)))
    {
        var value = Enum.Parse(typeof(RegistryRights), regItem);
	
        System.Diagnostics.Debug.WriteLine(regItem + "  " + ((int)value).ToString());
    }
