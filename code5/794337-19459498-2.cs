    public class MyServiceClient : DuplexClientBase<IMyService>
    {
        public MyServiceClient(object callbackInstance, Binding binding, EndpointAddress remoteAddress)
            : base(callbackInstance, binding, remoteAddress) { }
    }
    public class MyServiceCallbackClient : IMyServiceCallback
    {
        public event EventHandler<string> RecordResult; //If you are not using .net 4.5 you will need a custom class.
        void IMyServiceCallback.OnRecordResult(string result)
        {
           var tmp = RecordResult;
           if(tmp != null)
               tmp(this, result);
        }
    }
    IEnumerable<string> GetRecords(string parameter)
    {
        var uri = //...
        var binding = //...
        using(var collection = new BlockingCollection<string>())
        {
            var callback = new MyCallbackClient();
            callback.RecordResult += (o, result) =>
            {
                 if(result != null)
                     collection.Add(result);
                 else
                     collection.CompleteAdding(); //when we get a null we mark the collection complete
            }
            var client = new MyServiceClient(callback, binding, new EndpointAddress(uri));
            var proxy = client.ChannelFactory.CreateChannel();
            proxy.GetRecords();
            foreach(var record in collection.GetConsumingEnumerable())
            {
                yield return record;
            }
            client.Close();
         }
    }
 
