    public class classA {
        public Action<string> DataReceivedCallback = null;
    
        public void SendProcessedString() {
            if (null != DataReceivedCallback) { DataReceivedCallback.Invoke(data); }
        }
    }
