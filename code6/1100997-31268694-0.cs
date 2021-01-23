      private string _pathToConfigFiles;
            public string PathToConfigFiles
            {
                get
                {
                    return Path.Combine(this._pathToConfigFiles, this.GlobalSettings.grabSetting("configdirectory"));
                }
                set
                {
                    this._pathToConfigFiles = value;
                }
            }
