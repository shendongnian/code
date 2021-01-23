    //MISMATCH BETWEEN CLASS AND ITS PROPERTIES ACCESS MODIFIERS
    private class CommonConfig {
        public TimeSpan Period1 { get; private set; }
        public TimeSpan Period2 { get; private set; }
        public TimeSpan Period3 { get; private set; }
    
    }
