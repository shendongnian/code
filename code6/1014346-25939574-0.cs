        void SetNewEndpointAddress(string endpointName, string contractName, string newValue)
        {
            bool settingsFound = false;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ClientSection section = config.GetSection("system.serviceModel/client") as ClientSection;
            foreach (ChannelEndpointElement ep in section.Endpoints)
            {
                if (ep.Name == endpointName && ep.Contract == contractName)
                {
                    settingsFound = true;
                    ep.Address = new Uri(newValue);
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            if (!settingsFound)
            {
                throw new Exception(string.Format("Settings for Endpoint '{0}' and Contract '{1}' was not found!", endpointName, contractName));
            }
        }
