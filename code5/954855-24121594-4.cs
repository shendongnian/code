    class BlockingPipe : Pipe
    {
        public BlockingPipe(IList<string> calls) : base(calls) { }
        private enum State { ServerCalled, ServerNotCalled }
        private State state = State.ServerNotCalled;
        public override void Server(string s)
        {
            lock (this)
            {
                base.Server(s);
                state = State.ServerCalled;
                Monitor.Pulse(this);
            }
        }
        public override void Client(string s)
        {
            lock (this)
            {
                while (state != State.ServerCalled)
                    Monitor.Wait(this, 200);
                base.Client(s);
            }
        }
    }
