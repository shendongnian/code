    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    
    class Program
    {
        object _lock = new Object(); // sync lock 
        List<Task> _connections = new List<Task>(); // pending connections
    
        // The core server task
        private async Task StartListener()
        {
            var tcpListener = TcpListener.Create(8000);
            tcpListener.Start();
            while (true)
            {
                var tcpClient = await tcpListener.AcceptTcpClientAsync();
                Console.WriteLine("[Server] Client has connected");
                var task = StartHandleConnectionAsync(tcpClient);
                // if already faulted, re-throw any error on the calling context
                if (task.IsFaulted)
                    task.Wait();
            }
        }
    
        // Register and handle the connection
        private async Task StartHandleConnectionAsync(TcpClient tcpClient)
        {
            // start the new connection task
            var connectionTask = HandleConnectionAsync(tcpClient);
    
            // add it to the list of pending task 
            lock (_lock)
                _connections.Add(connectionTask);
    
            // catch all errors of HandleConnectionAsync
            try
            {
                await connectionTask;
                // we may be on another thread after "await"
            }
            catch (Exception ex)
            {
                // log the error
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // remove pending task
                lock (_lock)
                    _connections.Remove(connectionTask);
            }
        }
    
        // Handle new connection
        private async Task HandleConnectionAsync(TcpClient tcpClient)
        {
            await Task.Yield();
            // continue asynchronously on another threads
    
            using (var networkStream = tcpClient.GetStream())
            {
                var buffer = new byte[4096];
                Console.WriteLine("[Server] Reading from client");
                var byteCount = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                var request = Encoding.UTF8.GetString(buffer, 0, byteCount);
                Console.WriteLine("[Server] Client wrote {0}", request);
                var serverResponseBytes = Encoding.UTF8.GetBytes("Hello from server");
                await networkStream.WriteAsync(serverResponseBytes, 0, serverResponseBytes.Length);
                Console.WriteLine("[Server] Response has been written");
            }
        }
    
        // The entry point of the console app
        static void Main(string[] args)
        {
            Console.WriteLine("Hit Ctrl-C to exit.");
            new Program().StartListener().Wait();
        }
    }
