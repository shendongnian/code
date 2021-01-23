        // Create MetadataSet from address provided
        private MetadataSet GetMetadata()
        {
            Debug.Assert(string.IsNullOrWhiteSpace(m_mexAddress) == false);
            var mexUri = new Uri(m_mexAddress);
            var mexClient = new MetadataExchangeClient(mexUri, MetadataExchangeClientMode.MetadataExchange)
            {
                ResolveMetadataReferences = true
            };
            return mexClient.GetMetadata();
        }
        // Getting or updating contract descriptions and service endpoints
        private void UpdateMetadata(MetadataSet metadataSet)
        {
            if (metadataSet == null) 
                throw new ArgumentNullException("metadataSet");
            MetadataImporter metadataImporter = new WsdlImporter(metadataSet);
            m_contractDescriptions = metadataImporter.ImportAllContracts();
            m_serviceEndpoints = metadataImporter.ImportAllEndpoints();
        }
        // Compile metadata
        private CompilerResults CompileMetadata()
        {
            Debug.Assert(string.IsNullOrWhiteSpace(m_contractName) == false);
            Debug.Assert(m_contractDescriptions != null);
            Debug.Assert(m_serviceEndpoints != null);
            var generator = new ServiceContractGenerator();
            
            m_serviceContractEndpoints.Clear();
            foreach (var contract in m_contractDescriptions)
            {
                generator.GenerateServiceContractType(contract);
                m_serviceContractEndpoints[contract.Name] = m_serviceEndpoints.Where(
                    se => se.Contract.Name == contract.Name).ToList();
            }
            if (generator.Errors.Count != 0)
                throw new InvalidOperationException("Compilation errors");
            var codeDomProvider = CodeDomProvider.CreateProvider("C#");
            var compilerParameters = new CompilerParameters(
                new[]
                {
                    "System.dll", "System.ServiceModel.dll",
                    "System.Runtime.Serialization.dll"
                }) { GenerateInMemory = true };
            var compilerResults = codeDomProvider.CompileAssemblyFromDom(compilerParameters,
                generator.TargetCompileUnit);
            if (compilerResults.Errors.Count > 0)
                throw new InvalidOperationException("Compilation errors");
            return compilerResults;
        }
