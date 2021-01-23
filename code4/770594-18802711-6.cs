    RegistryKey rKey = Registry.ClassesRoot.OpenSubKey(@"Directory\shell", true);
    String[] names = rKey.GetSubKeyNames();
    foreach (String s in names)
    {
        System.Windows.Forms.MessageBox.Show(s);
    }
    RegistryKey newKey = rKey.CreateSubKey("Create HTML Folder");
    RegistryKey newSubKey = newKey.CreateSubKey("command");
    newSubKey.SetValue("", @"C:\Users\Aviv\Desktop\basicFileCreator.exe " + "\"" + "%1" + "\"");
    newSubKey.Close();
    newKey.Close();
    rKey.Close();   
