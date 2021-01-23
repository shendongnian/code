        Func<Owned<ISynchProcessor>> syncProcessor;
        Mock<ISynchProcessor> proc = new Mock<ISynchProcessor>();
        [TestInitialize]
        public void TestInitialize()
        {        
            syncProcessor = () => new Owned<ISynchProcessor>(proc.Object, new Mock<IDisposable>().Object);         
        }
