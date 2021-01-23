     private void button1_Click(object sender, EventArgs e)
            {
            
               string outputkey = @"\key.dat";
    
                //save registry to dat file
               SaveRamBasedRegistry(outputkey);
                //Restore registry file
               RestoreRamBasedRegistry(outputkey);
            }
    
    
         
            public static void SaveRamBasedRegistry(string destinationPath)
            {
                RegistryHelper.SaveRamBasedRegistry(destinationPath);
            }
    
            public static void RestoreRamBasedRegistry(string destinationPath)
            {
                RegistryHelper.RestoreRamBasedRegistry(destinationPath);
            }
