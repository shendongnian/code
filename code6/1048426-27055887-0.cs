    public static class SharedTracerMock
    {
        private static readonly Mock<ITracer> tracerMock = new Mock<ITracer>();
    
        public static Mock<ITracer> TracerMock { get { return tracerMock; } }
    }
