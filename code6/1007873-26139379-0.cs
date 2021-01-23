       public static string PathName
         { 
          get
             {
              RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\ExampleTest")
              string registryContent = (Registry.GetValue(registryKey.Name, "Con", "not exist")).ToString();
              return registryContent;  
             }
         }
