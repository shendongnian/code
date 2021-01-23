    public static class ConnectorExtensions
    {
        public static bool DoesPassGripTest(this Connector connector, Board board)
        {
            var analyzer = ConnectorAnalyzerRepository.GetGripAnalyzer(connector);
            if (analyzer == null)
                throw new ArgumentException("Invalid connector type"); // Do whatever you want with the failure
                
            return analyzer.DoesPassGripTest(board);
        }
    }
    
