    public class BaseClass {
        private Timer tmrWork;
        public BaseClass() {
            // read values from config
            tmrWork = new Timer(tmrWork_Tick, null, 1, SomeInterval);
            lock (syncObject)
                Init();
        }
        protected abstract void Init();
        private void tmrWork_Tick(object state)
        {
            lock (syncObject)
                DoWork();
        } 
        protected abstract void DoWork();
    }
    public class ChildClass: BaseClass {
        private object syncObject = new object();
        protected override void Init() {
            lock (syncObject) {
                // do a bunch of stuff here
                // potentially time consuming
            }
        }
        protected override void DoWork() {
            // do stuff
        }
    }
