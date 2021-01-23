    After little changes in the code previously given by JasRaj to create registry entry
    
    
    
    private string _subKey = "SOFTWARE\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION";
    private string SubKey
    {
        get { return _subKey; }
        set { _subKey = value; }
    }
    
    private RegistryKey _baseRegistryKey = Registry.LocalMachine;
    
    private RegistryKey BaseRegistryKey
    {
        get { return _baseRegistryKey; }
        set { _baseRegistryKey = value; }
    }
    
     private bool WriteDbToRegistry(string keyName, object value)
    {
        try
        {
            var rk = BaseRegistryKey;
            var sk1 = rk.OpenSubKey(SubKey,true); //true is required for making it writable
            if (sk1 != null)
            {
                sk1.SetValue(keyName, value,RegistryValueKind.DWord); //dword,qword 
                rk.Close();
                sk1.Close();
                return true;
            }
            else
            {
                rk.Close();
                sk1.Close();
                return false;
            }
            
        }
        catch(Exception e)
        {
            MessageBox.Show(e.Message);
            return false;
        }
    }
    
     public string GetRegistryValue(string keyname)
     {
         var rk = BaseRegistryKey;
         var sk1 = rk.OpenSubKey(SubKey);
         try
         {
             return sk1.GetValue(keyname).ToString();
         }
         catch (Exception e)
         {
             MessageBox.Show(e.Message, "Error");
             return null;
         }
     }
