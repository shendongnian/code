    [ServiceContract]
    public interface IMyServiceCallback
    {        
        [OperationContract(IsOneWay = true)]        
        void RecordResult(string result);
    }
    
    [ServiceContract(CallbackContract = typeof(IMyServiceCallback))]
    public interface IMyService
    {
        [OperationContract(IsOneWay = true)]
        void GetRecords(string parameter);
    }
    
    public class MyService: IMyService
    {
        public void GetRecords(string parameter)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMyServiceCallback>();
        
            using(var resultCollection = ProcessRecords(parameter))
            {
                foreach(var record in resultCollection.GetConsumingEnumerable())
                {
                    //Transmit the results back to the client as they get put in to resultCollection.
                    callback.RecordResult(record);
                }
            }
            
            //We return null as a signal that we are done reporting results, you could also add a 2nd method to the callback to represent being done.
            callback.RecordResult(null);
        }
    
        private static BlockingCollection<string> ProcessRecords(string parameter)
        {
             var collection = new BlockingCollection<string>();
    
             //We populate the blocking collection in a background thread.
             Task.Run(() => StartProcessingRecords(parameter, collection);
    
             return collection;
        }
    
        private static void StartProcessingRecords(string parameter, BlockingCollection<string> collection)
        {
            //...
        }
    }
