        using System.Xml.Serialization;
        using PCLStorage;
        using System.IO;
        public virtual async Task<T> LoadSettings<T>(IFile file = null)
            where T : IApplicationSettings
        {
            // File
            if (file == null)
                file = DefaultSettingsFile;
            // Open file
            using (Stream fileStream = await file.OpenAsync(FileAccess.Read))
            {
                var xmls = new XmlSerializer(typeof(T));
                return (T)xmls.Deserialize(fileStream);
            }
        }
        public virtual async Task SaveSettings(object settings, IFile file = null)
        {
            // File
            if (file == null)
                file = DefaultSettingsFile;
            // Open file
            using (Stream fileStream = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                var xmls = new XmlSerializer(settings.GetType());
                xmls.Serialize(fileStream, settings);
            }
        }
