    public class MessageProcessorFactory
    {
        private MessageProcessorFactory() { }
        private static readonly MessageProcessorFactory _instance = new MessageProcessorFactory();
        public static MessageProcessorFactory Instance { get { return _instance; }}
        private IEnumerable<IProcessMessage> _processorCollection;
        IEnumerable<IProcessMessage> ProcessorCollection
        {
            get
            {
                if (_processorCollection == null)
                {
                    //use reflection to find all imlementation of IProcessMessage
                    //or initialize it manualy
                    _processorCollection = new List<IProcessMessage>()
                    {
                        new processorM1Ver1(),
                        new processorM2Ver1(),
                        new processorM1Ver2()
                    };
                }
                return _processorCollection;
            }
        } 
        internal IProcessMessage GetProcessor(string action)
        {
            var algorithVersion = ReadAlgorithVersion();
            var processor = ProcessorCollection.FirstOrDefault(x => x.AlgorithmVersion == algorithVersion && x.ActionVersion == action);
            return processor;
        }
        private string ReadAlgorithVersion()
        {
            //read from config file
            //or from database
            //or where this info it is kept
            return "ver1";
        }
    }
