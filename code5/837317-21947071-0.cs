    [Export(typeof(ITestContainerDiscoverer))]
    [Export(typeof(Testything))]
    internal class Testything : ITestContainerDiscoverer
    {
    
        [ImportingConstructor]
        internal Testything([Import(typeof(IOperationState))]IOperationState operationState)
        {
            operationState.StateChanged += OperationState_StateChanged;
         }
    
        public Uri ExecutorUri => new Uri("executor://PrestoCoverageExecutor/v1");
    
    
        public IEnumerable<ITestContainer> TestContainers
        {
            get
            {
                return new ITestContainer[0].AsEnumerable();
            }
        }
    
    
        public event EventHandler TestContainersUpdated;
    
        private void OperationState_StateChanged(object sender, OperationStateChangedEventArgs e)
        {
            if (e.State == TestOperationStates.TestExecutionFinished)
            {
                var s = e.Operation;
            }
        }
    }
