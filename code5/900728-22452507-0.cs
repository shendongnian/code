    public sealed class ExeConfigurationFileMap : ConfigurationFileMap 
    {
        string  _exeConfigFilename;
        string  _roamingUserConfigFilename;
        string  _localUserConfigFilename;
        public ExeConfigurationFileMap(string machineConfigFileName)
                : base(machineConfigFileName) 
        {
            _exeConfigFilename = String.Empty;
            _roamingUserConfigFilename = String.Empty;
            _localUserConfigFilename = String.Empty;
        }
        public string ExeConfigFilename 
        {
            get 
            {
                return _exeConfigFilename;
            }
            set 
            {
                _exeConfigFilename = value;
            }
        }
