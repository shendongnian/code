    public interface ISomeWebServiceClientProxy {
        Data LoadData();
    }
    class RealSomeWebServiceClientProxy : ISomeWebServiceClientProxy {
        private readonly string uri;
        public RealSomeWebServiceClientProxy(string uri) {
            this.uri = uri;
        }
        public Data LoadData() {
            // use uri, call web service, return data.
        }
    }
