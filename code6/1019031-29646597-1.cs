        protected override ServiceEndpoint CreateDescription()
        {
            ServiceEndpoint description = base.CreateDescription();
            if (CustomisedChannelFactory<TChannel>.ConfigurationPath == null || !System.IO.File.Exists(CustomisedChannelFactory<TChannel>.ConfigurationPath))
                return base.CreateDescription();
            ServiceModelSectionGroup sectionGroup = ServiceModelSectionGroup.GetSectionGroup(ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap()
            {
                ExeConfigFilename = CustomisedChannelFactory<TChannel>.ConfigurationPath
            }, ConfigurationUserLevel.None));
            ChannelEndpointElement channelEndpointElement1 = (ChannelEndpointElement)null;
            foreach (ChannelEndpointElement channelEndpointElement2 in (ConfigurationElementCollection)sectionGroup.Client.Endpoints)
            {
                if (channelEndpointElement2.Contract == description.Contract.ConfigurationName)
                {
                    channelEndpointElement1 = channelEndpointElement2;
                    break;
                }
            }
            if (channelEndpointElement1 != null)
            {
                if (description.Binding == null)
                    description.Binding = this.CreateBinding(channelEndpointElement1.Binding, channelEndpointElement1.BindingConfiguration, sectionGroup);
                if (description.Address == (EndpointAddress)null)
                    description.Address = new EndpointAddress(channelEndpointElement1.Address, this.GetIdentity(channelEndpointElement1.Identity), channelEndpointElement1.Headers.Headers);
                if (description.Behaviors.Count == 0 && !string.IsNullOrEmpty(channelEndpointElement1.BehaviorConfiguration))
                    this.AddBehaviors(channelEndpointElement1.BehaviorConfiguration, description, sectionGroup);
                description.Name = channelEndpointElement1.Contract;
            }
            return description;
        }
        private Binding CreateBinding(string bindingName, string bindingConfigurationName, ServiceModelSectionGroup group)
        {
            BindingCollectionElement collectionElement = group.Bindings[bindingName];
            if (collectionElement.ConfiguredBindings.Count <= 0)
                return (Binding)null;
            IBindingConfigurationElement configurationElement = null;
            foreach (IBindingConfigurationElement bce in collectionElement.ConfiguredBindings)
            {
                if (bce.Name.Equals(bindingConfigurationName))
                {
                    configurationElement = bce;
                    break;
                }
            }
            if (configurationElement == null) throw new Exception("BindingConfiguration " + bindingConfigurationName + " not found under binding " + bindingName);
            Binding binding = this.GetBinding(configurationElement);
            if (configurationElement != null)
                configurationElement.ApplyConfiguration(binding);
            return binding;
        }
 
