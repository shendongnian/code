    public class NailConnectorGripAnalyzer : ConnectorGripAnalyzer<NailConnector>
    {
        public override bool DoesPassGripTest(Board board)
        {
            return true;
        }
    }
    public class ScrewConnectorGripAnalyzer : ConnectorGripAnalyzer<ScrewConnector>
    {
        public override bool DoesPassGripTest(Board board)
        {
            return true;
        }
    }
