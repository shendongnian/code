    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                // Retrieve the userSettings gorup
                ConfigurationSectionGroup group = config.SectionGroups[@"userSettings"];
                if (group == null) return;
                // Get the program settings
                ClientSettingsSection clientSection = group.Sections["CA.Properties.Settings"] as ClientSettingsSection;
                if (clientSection == null) return;
                // This retrieves the value associated with the key
                string sFileName = clientSection.Settings.Get("ab123").Value.ValueXml.InnerText;
                // Check if ab123 has a value and the file exists
                if (!string.IsNullOrEmpty(sFileName) && System.IO.File.Exists(sFileName))
                {
                    using (StreamReader sr = new StreamReader(sFileName))
                    {
                        string line;
                        // Read and display lines from the file until the end of  
                        // the file is reached. 
                        while ((line = sr.ReadLine()) != null)
                        {
                            System.Diagnostics.Debug.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
