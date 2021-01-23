    public class AsyncSerialPort
    {
        private SerialPort port;
        private Task lastRequest = Task.FromResult(true);
        public AsyncSerialPort()
        {
            //initialize port here
        }
        public Task SendAndGet()
        {
            lock (lastRequest)
            {
                var result = SendAndGetImpl();
                lastRequest = result;
                return result;
            }
        }
        private async Task SendAndGetImpl()
        {
            await lastRequest;
            //send data to port
            var type = await port.WhenDataRecieved();
            //process the received data
                
        }
    }
