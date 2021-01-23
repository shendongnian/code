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
                var sk1 = rk.CreateSubKey(SubKey);
                if(sk1 != null) sk1.SetValue(keyName.ToUpper(), value);
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show("Please run your App as Administrator.", "Administrator");
                return false;
            }
        }
     bool results = WriteDbToRegistry("myapp.exe", "2710");
