        /// <summary>
        /// Gets the type configuration.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>AbstractTypeConfiguration.</returns>
        public AbstractTypeConfiguration GetTypeConfiguration(object obj)
        {
            var type = obj.GetType();
            var config = TypeConfigurations.ContainsKey(type) ? TypeConfigurations[type] : null;
            if (config != null) return config;
            //check base type encase of proxy
            config = TypeConfigurations.ContainsKey(type.BaseType) ? TypeConfigurations[type.BaseType] : null;
            if (config != null) return config;
            //check interfaces encase this is an interface proxy
            string name = type.Name;
            //ME - I added the OrderByDescending in response to issue 53
            // raised on the Glass.Sitecore.Mapper project. Longest name should be compared first
            // to get the most specific interface
            var interfaceType = type.GetInterfaces().OrderByDescending(x=>x.Name.Length).FirstOrDefault(x => name.Contains(x.Name));
            if (interfaceType != null)
                config = TypeConfigurations.ContainsKey(interfaceType) ? TypeConfigurations[interfaceType] : null;
            
            return config;
        }
