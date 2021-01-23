        private struct settingsStruct
        {
            ...
            ...
            public bool makeNewIe8InstanceNoMerge;
            public bool closeExistingFireFoxInstances;
            public bool incognitoMode;
        }
        public bool OpenInIncognitoMode
        {
            get { return settings.incognitoMode; }
            set { settings.incognitoMode = value; }
        }
        private void SetDefaults()
        {
            settings = new settingsStruct
            {
				...
				...
				makeNewIe8InstanceNoMerge = true,
				closeExistingFireFoxInstances = true,
				incognitoMode = false
            };
        }
