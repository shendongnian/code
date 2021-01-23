        private readonly string[] files;
        private Settings setting;
        public FileAdding(string[] files, Settings setting)
                {
                    this.files = files;
                    this.setting= setting;
                }
    
    public Settings Settings
            {
                get { return this.setting; }
                set
                {
                    this.setting= value;
                    OnPropertyChanged(() => Settings);
                }
            }
    
    public bool Initialize()
            {
               Settings.BusyDoingAction = true;
               return true;
            }
    
    public bool Deinitialize()
             {
               Settings.BusyDoingAction = false;
               return true;
             }
