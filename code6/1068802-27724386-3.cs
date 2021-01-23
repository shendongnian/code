    public class ConnectorGripAnalyzer<T> : IConnectorGripAnalyzer where T : Connector
    {
        public Type ConnectorType 
        { 
            get { return typeof(T); }
        }
        
        public virtual bool DoesPassGripTest(Board board)
        {
            return true;
        }
    }
    
