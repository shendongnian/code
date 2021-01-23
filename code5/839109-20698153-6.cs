    private sealed partial class Client
    {
        private sealed class Sender
        {
            internal void SendData(byte[] data)
            {
                // transition the data to the thread and send it...
            }
    
            internal Sender(NetworkStream stream)
            {
                _stream = stream;
                _thread = new Thread(Run);
                _thread.Start();
            }
            private void Run()
            {
                // main thread loop for sending data...
            }
    
            private NetworkStream _stream;
            private Thread        _thread;
        }
    }
