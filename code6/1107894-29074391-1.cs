    public class ResultsAgent : IResultsAgent
    {
        private static readonly MethodInfo GenericProcessMethod = typeof(ResultsAgent).GetMethod("ProcessGeneric");
        private readonly IResolutionRoot resolutionRoot;
        public ResultsAgent(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
        public void Store(SearchResult message)
        {
            GenericProcessMethod.MakeGenericMethod(message.GetType())
                .Invoke(this, new object[] { message });
        }
        public void ProcessGeneric<TMessage>(TMessage message)
            where TMessage : SearchResult
        {
            var handler = this.resolutionRoot.Get<IPersist<TMessage>>();
            Console.WriteLine("ResultsAgent will use: " + handler.GetType().FullName + " to persist");
            handler.Persist(message);
        }
    }
