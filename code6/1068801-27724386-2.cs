    public interface IConnectorGripAnalyzer
    {
        Type ConnectorType { get; }
        bool DoesPassGripTest(Board board);
    }
    
