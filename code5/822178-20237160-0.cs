    class APIAdapter {
        readonly object AdapterLock = new object();
        private readonly BlockingCollection<Tuple<object, EventArgs>> PendingEvents = new BlockingCollection<Tuple<object, EventArgs>>();
        ExternalAPI API = new ExternalAPI();
    
        APIAdapter() {
            ExternalAPI.Data += ExternalAPI_Data;
            Task.Factory.StartNew(Consume, TaskCreationOptions.LongRunning);
        }
    
        public void Consume() {
            foreach (var e in this.PendingEvents.GetConsumingEnumerable()) {
                if (this.PendingEvents.IsAddingCompleted) return;
                ProcessData(e.Item1, e.Item2);
            }
        }
    
        public void RequestData() {
            lock (this.AdapterLock) {
                this.ExternalAPI.SynchronousDataRequest(); 
            }
        }
    
        private void ExternalAPI_Data(object sender, EventArgs e) {
            this.PendingEvents.Add(Tuple.Create(sender, e));
        }
    
        private void ProcessData(object sender, EventArgs e) {
            lock (this.AdapterLock) {
                Console.Write("Received event.");
            }
        }
    }
