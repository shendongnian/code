        public Version Version
        {
            get
            {
                Assembly assembly = this.GetType().Assembly;
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;
                return new Version(version);
            }
        }
