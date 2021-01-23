    namespace TcpServer
    {
        using System;
        using System.Collections.Generic;
        using System.Net;
        using System.Net.Sockets;
        using System.Text;
        using System.Threading;
        /// <summary>
        /// Contains possible exit codes for the application.
        /// </summary>
        public enum ApplicationExitCode
        {
            /// <summary>
            /// Represents an exit code which hint's that there was an abnormal program termination.
            /// </summary>
            Error = 1,
            /// <summary>
            /// Represents an exit code which hint's that there was no abnormal program termination.
            /// </summary>
            OK = 0
        }
        /// <summary>
        /// Represents out Program class.
        /// </summary>
        public class Server
        {
            /// <summary>
            /// Represents the port on which the server will try to listen.
            /// </summary>
            private const int SERVERPORT = 12345;
            /// <summary>
            /// Represents the threads that handle the client connections.
            /// </summary>
            private static List<Thread> clientThreads = new List<Thread>();
            /// <summary>
            /// The entry point of our application.
            /// </summary>
            /// <param name="args">The command line arguments.</param>
            public static void Main(string[] args)
            {
                // Establish a tcpListener on any network interface at port SERVERPORT
                IPEndPoint localEndpoint = new IPEndPoint(IPAddress.Any, SERVERPORT);
                TcpListener listener = new TcpListener(localEndpoint);
                try
                {
                    // Try to start the listener which will try to bind to the socket.
                    listener.Start();
                }
                catch (SocketException socketEx)
                {
                    Console.WriteLine("Server: Unable to establish listener at {0}:{1}", localEndpoint.Address.ToString(), localEndpoint.Port.ToString());
                    Console.WriteLine(socketEx.Message);
                    Environment.Exit((int)ApplicationExitCode.Error);
                }
                // Print status information.
                Console.WriteLine("Server: You can terminate the application by pressing the ESC-key.");
                Console.WriteLine("Server: Listener at {0}:{1} established, waiting for incomming connections...", localEndpoint.Address.ToString(), localEndpoint.Port.ToString());
                bool listenForClients = true; // Used for controlling the listener loop.
                int connectionID = 0; // Used for distinguishing the connections in the console output.
                do
                {
                    // Check for user input.
                    if (Console.KeyAvailable)
                    {
                        listenForClients = Console.ReadKey(true).Key != ConsoleKey.Escape;
                    }
                    // Check for new client.
                    if (listener.Pending())
                    {
                        // Create a new thread for the connecting client.
                        Thread t = new Thread(new ParameterizedThreadStart(ClientWorker));
                        // Set the thread as background thread (which would/could terminate with the main thread - we don't want that).
                        t.IsBackground = true;
                        // Set the thread name to the connectionID (which is a number increasing with each new client).
                        t.Name = (connectionID++).ToString();
                        // Start the thread and pass a reference to the new client object which we receive from AcceptTcpClient().
                        t.Start((object)listener.AcceptTcpClient());
                        // Add the thread to the list so we can terminate it later.
                        clientThreads.Add(t);
                    }
                    else
                    {
                        // Sleep - I like that ;-)
                        Thread.Sleep(100);
                    }
                }
                while (listenForClients);
                // Stop the listener.
                listener.Stop();
                // Print status message.
                Console.WriteLine("Server: Sending abort request to all threads.");
                // Send abort request to all client threads.
                foreach (Thread t in clientThreads)
                {
                    t.Abort();
                }
                // Print status message.
                Console.WriteLine("Server: Waiting for all threads to terminate.");
                // Wait for all client threads to really terminate.
                foreach (Thread t in clientThreads)
                {
                    t.Join();
                }
                // Print status message.
                Console.WriteLine("Server: Exiting application.");
                // Exit the application.
                Environment.Exit((int)ApplicationExitCode.OK);
            }
            /// <summary>
            /// Represents the client thread which is started for each new connection.
            /// </summary>
            /// <param name="data">The tcpClient object.</param>
            private static void ClientWorker(object data)
            {
                TcpClient tcpClient = (TcpClient)data;
                NetworkStream ns;
                string threadName = Thread.CurrentThread.Name;
                bool processData = true;
                Console.WriteLine("Thread {0}: Started.", threadName);
                // Try to fetch the network stream
                try
                {
                    ns = tcpClient.GetStream();
                }
                catch
                {
                    Console.WriteLine("Thread {0}: Unable to fetch the network stream, exiting thread.", threadName);
                    return;
                }
                // Print cool message.
                Console.WriteLine("Thread {0}: Network stream fetched.", threadName);
                try
                {
                    byte[] receiveBuffer = new byte[1024];
                    byte[] sendBuffer;
                    int bytesRead = 0;
                    string message;
                    while (processData)
                    {
                        // If data is available on the stream
                        if (ns.DataAvailable)
                        {
                            // Read data from the stream.
                            bytesRead = ns.Read(receiveBuffer, 0, receiveBuffer.Length);
                            // Write the received number of bytes.
                            Console.WriteLine("Thread {0}: Received {1} bytes.", threadName, bytesRead);
                            // Write the bytes (in hex format).
                            Console.Write("Thread {0}: ", threadName);
                            for (int i = 0; i < bytesRead; i++)
                            {
                                Console.Write("{0:X2} ", receiveBuffer[i]);
                            }
                            // "Decode" the data.
                            message = Encoding.ASCII.GetString(receiveBuffer, 0, bytesRead);
                            Console.WriteLine("\nThread {0}: Decoding data using ASCII table.", threadName);
                            // Write the decoded message.
                            Console.WriteLine("Thread {0}: {1}", threadName, message);
                            // Build the answer byte array.
                            sendBuffer = Encoding.ASCII.GetBytes("Hab's bekommen ;-)\r\n");
                            // Write the answer.
                            ns.Write(sendBuffer, 0, sendBuffer.Length);
                        }
                        else
                        {
                            Thread.Sleep(100);
                        }
                    }
                }
                catch (ThreadAbortException)
                {
                    // Print status message.
                    Console.WriteLine("Thread {0}: Abort requested.", threadName);
                
                    // Set loop condition.
                    processData = false;
                    // Reset abort request.
                    Thread.ResetAbort();
                }
                catch (Exception generalEx)
                {
                    Console.WriteLine("Thread {0}: Exception occured.", threadName);
                    Console.WriteLine("Thread {0}: {1}", threadName, generalEx.Message);
                }
                finally
                {
                    // If the network stream still exists.
                    if (ns != null)
                    {
                        // Flush the stream.
                        ns.Flush();
                        // Close the stream.
                        ns.Close();
                        // Dispose the stream.
                        ns.Dispose();
                    }
                    // If the tcpClient object still exists.
                    if (tcpClient != null)
                    {
                        // Close the client.
                        tcpClient.Close();
                    }
                    // Print status message.
                    Console.WriteLine("Thread {0}: Stopping.", threadName);
                }
            }
        }
    }
