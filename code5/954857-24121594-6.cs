    class Pipe
    {
        internal static int counter = 0;
        private readonly int id = counter++;
        private readonly IList<string> calls;
        public Pipe(IList<string> calls) { this.calls = calls; }
        public virtual void Server(string s) { EnqueeCall(s, "server"); }
        public virtual void Client(string s) { EnqueeCall(s, "client"); }
        private void EnqueeCall(string s, string actor)
        {
            calls.Add(actor + id + " processes " + s);
        }
    }
