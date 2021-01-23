    public class CustomSocket : Socket {
        private EndPoint endPoint;
        public CustomSocket(EndPoint endPoint, SocketType socketType, ProtocolType protocolType)
            : base(endPoint.AddressFamily, socketType, protocolType) {
                this.endPoint = endPoint;
        }
        public virtual void Bind() {
            try {
                base.Bind(endPoint);
            } catch {
                // do logging here
                throw new Exception("Bind() failed");
            }
        }
        public virtual void Listen(int backlog) {
            try {
                base.Listen(backlog);
            } catch {
                // do logging here
                throw new Exception("Listen() failed");
            }
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
        }
    }
