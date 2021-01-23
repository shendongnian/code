    private static void CryptConfig (string[] sectionKeys)
    {
      Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      foreach (string sectionKey in sectionKeys)
      { 
      ConfigurationSection section = config.GetSection(sectionKey);
      if (section != null)
      {
        if (section.ElementInformation.IsLocked)
        {
          Console.WriteLine("Section: {0} is locked", sectionKey);
        }
        else
        {
          if (!section.SectionInformation.IsProtected)
          {
            //%windir%\system32\Microsoft\Protect\S-1-5-18
            section.SectionInformation.ProtectSection(DPCP);
            section.SectionInformation.ForceSave = true;
            Console.WriteLine("Encrypting: {0} {1}", section.SectionInformation.Name, section.SectionInformation.SectionName);
            
          }
          else
          { // display values for current config application name value pairs
            foreach (KeyValueConfigurationElement x in config.AppSettings.Settings)
            {
              Console.WriteLine("Key: {0} Value:{1}", x.Key, x.Value);
            }
            foreach (ConnectionStringSettings x in config.ConnectionStrings.ConnectionStrings)
            {
              Console.WriteLine("Name: {0} Provider:{1} Cs:{2}", x.Name, x.ProviderName, x.ConnectionString);
            }
            //
            section.SectionInformation.UnprotectSection();
            section.SectionInformation.ForceSave = true;
            Console.WriteLine("Decrypting: {0} {1}", section.SectionInformation.Name, section.SectionInformation.SectionName);
          }
        }        
      }
      else
      {
        Console.WriteLine("Section: {0} is null", sectionKey);
      }
      }
      //
      config.Save(ConfigurationSaveMode.Full);
      Console.WriteLine("Saving file: {0}", config.FilePath);      
    }
