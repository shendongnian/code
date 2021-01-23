    public static class ConnectorAnalyzerRepository
    {
        private Dictionary<Type, IConnectorGripAnalyzer> connectorGripAnalyzers;
        
        public IConnectorGripAnalyzer GetGripAnalyzer(Connector connector)
        {
            if (connectorGripAnalyzers == null)
            {
                connectorGripAnalyzers = new Dictionary<Type, IConnectorGripAnalyzer>();
                
                var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(IConnectorGripAnalyzer).IsAssignableFrom(t));
                foreach (var t in types)
                {
                    var c = Activator.CreateInstance(t) as IConnectorGripAnalyzer;
                    if (c == null)
                        continue;
                        
                    connectorGripAnalyzers[c.ConnectorType] = c;
                }
            }
            
            return connectorGripAnalyzers.ContainsKey(typeof(connector)) ? connectorGripAnalyzers[typeof(connector)] : null;
        }
    }
   
