            XDocument configFile = XDocument.Load(fileToSearch);
            var section = configFile.Descendants(sectionToReplace).FirstOrDefault();
			// Replace section if enabled and replacement supplied.
            if (section != null && !string.IsNullOrEmpty(replacementString))
            {
                section.ReplaceWith(XElement.Parse(replacementString.Replace(@"\n", "
")));
            }
                //save the amended file
                var newConfigFile = new System.Xml.XmlDocument();
                newConfigFile.LoadXml(configFile.ToString());
                newConfigFile.Save(fileToSearch);
