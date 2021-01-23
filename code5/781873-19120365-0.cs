        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            
         
            
            string path = null;
            string registry_key = @"SOFTWARE\";
    // In my case I am getting the user selected current installation folder from the registry       
      using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    if (subkey_name == "Default Company Name")
                    {
                        using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                        {
                            path = (string)subkey.GetValue("InstallDir");
                           
                        }
                    }
                }
            }
           
            string fileName = "example.txt";
            string sourcePath = path;
            //Have created a folder named "tmp" in current innstallation folder.       
            string targetPath =System.IO.Path.Combine(path,"tmp");
            // Use Path class to manipulate file and directory paths. 
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            // To copy a folder's contents to a new location: 
            // Create a new target folder, if necessary. 
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
            //Copy the required file.
            System.IO.File.Copy(sourceFile, destFile, true); 
      }
