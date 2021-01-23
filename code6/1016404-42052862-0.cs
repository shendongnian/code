        public static void Add<T>(this ApplicationSettingsBase settings, string propertyName, T val)
        {           
            var p = new SettingsProperty(propertyName)
            {
                PropertyType = typeof(T),
                Provider = settings.Providers["LocalFileSettingsProvider"],
                SerializeAs = SettingsSerializeAs.Xml
            };
            
            p.Attributes.Add(typeof(UserScopedSettingAttribute), new UserScopedSettingAttribute());
            
            settings.Properties.Add(p);
            settings.Reload();
            //finally set value with new value if none was loaded from userConfig.xml
            var item = settings[propertyName];
            if (item == null)
            {
                settings[propertyName] = val;
                settings.Save();
            }
        }
