    public class cProducer {
        private cConsumer myConsumer = new cConsumer ();
        public void onStart () {
            myConsumer.OnStart ();
        }
 
        public void onStop () {
            myConsumer.OnStop ();
        }
        public void OnOrderReceived (cOrder newOrder) {
            myConsumer.orderQueue.Add (cOrder);
        }
    }
    public class cConsumer {
        private CancellationTokenSource stopFlag;
        public BlockingCollection<cOrder> orderQueue = new BlockingCollection<cOrder> ();
        private Task processingTask;
        public void OnStart () {
            stopFlag = new CancellationTokenSource ();
            processingTask = Task.Factory.StartNew (() => Process ());
        }
        public void OnStop () {
            stopFlag.Cancel ();
            orderQueue.CompleteAdding ();
            processingTask.Wait ();
        }
        private void Process () {
            try {
                foreach (cOrder newOrder in orderQueue.GetConsumingEnumerable (stopFlag.Token)) {
                    // process
                }
            }
            catch (OperationCanceledException) {
                foreach (cOrder cancelledOrder in orderQueue.GetConsumingEnumerable ()) {
                    // log it
                }
            }
        }
    }
