    public class ConfigurationLoader : IConfigurationService
    {
        private static string configFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rubberduck", "rubberduck.config");
        /// <summary>   Saves a Configuration to Rubberduck.config XML file via Serialization.</summary>
        public void SaveConfiguration<T>(T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
            using (TextWriter textWriter = new StreamWriter(configFile))
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
            }
        }
        /// <summary>   Loads the configuration from Rubberduck.config xml file. </summary>
        /// <remarks> If an IOException occurs, returns a default configuration.</remarks>
        public Configuration LoadConfiguration()
        {
            try
            {
                using (StreamReader reader = new StreamReader(configFile))
                {
                    var deserializer = new XmlSerializer(typeof(Configuration));
                    var config = (Configuration)deserializer.Deserialize(reader);
                    //deserialization can silently fail for just parts of the config, 
                    //  so we null check and return defaults if necessary.
                    if (config.UserSettings.ToDoListSettings == null)
                    {
                        config.UserSettings.ToDoListSettings = new ToDoListSettings(GetDefaultTodoMarkers());
                    }
                    return config;
                }
            }
            catch (IOException)
            {
                return GetDefaultConfiguration();
            }
            catch (InvalidOperationException ex)
            {
                var message = ex.Message + System.Environment.NewLine + ex.InnerException.Message + System.Environment.NewLine + System.Environment.NewLine +
                        configFile + System.Environment.NewLine + System.Environment.NewLine +
                        "Would you like to restore default configuration?" + System.Environment.NewLine + 
                        "Warning: All customized settings will be lost.";
                DialogResult result = MessageBox.Show(message, "Error Loading Rubberduck Configuration", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    var config = GetDefaultConfiguration();
                    SaveConfiguration<Configuration>(config);
                    return config;
                }
                else
                {
                    throw ex;
                }
            }
        }
        public Configuration GetDefaultConfiguration()
        {
            var userSettings = new UserSettings(new ToDoListSettings(GetDefaultTodoMarkers()));
            return new Configuration(userSettings);
        }
        public ToDoMarker[] GetDefaultTodoMarkers()
        {
            var note = new ToDoMarker("NOTE:", TodoPriority.Low);
            var todo = new ToDoMarker("TODO:", TodoPriority.Normal);
            var bug = new ToDoMarker("BUG:", TodoPriority.High);
            return new ToDoMarker[] { note, todo, bug };
        }
    }
