    try
    {
        using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\MySQL AB\\MySQL Connector\\Net"))
        {
            if (key != null)
            {
                Object o = key.GetValue("Version");
                if (o != null)
                {
                    Version version = new Version(o as String);  //"as" because it's REG_SZ...otherwise ToString() might be safe(r)
                    //do what you like with version
                }
            }
        }
    }
    catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
    {
        //react appropriately
    }
