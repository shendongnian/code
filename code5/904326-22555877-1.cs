    namespace TcpClient
    {
        using System;
        using System.Net;
        using System.Net.Sockets;
        using System.Text;
        /// <summary>
        /// Represents our Server class.
        /// </summary>
        public class Client
        {
            /// <summary>
            /// The entry point of our application.
            /// </summary>
            /// <param name="args">The command line arguments.</param>
            public static void Main(string[] args)
            {
                IPAddress ipAddress;
                IPEndPoint ipEndPoint;
                TcpClient tcpClient;
                NetworkStream ns = null;
                int port;
                // Let the user input the IP-Address.
                Console.Write("Bitte geben Sie die IPAdresse an: ");
                ipAddress = IPAddress.Parse(Console.ReadLine());
                // Let the user input the port number.
                Console.Write("Bitte geben Sie den Port an: ");
                port = int.Parse(Console.ReadLine());
                // Create a new IPEndPoint object.
                ipEndPoint = new IPEndPoint(ipAddress, port);
                // Create a new TcpClient object.
                tcpClient = new TcpClient();
                // Connect the client to the endpoint.
                tcpClient.Connect(ipEndPoint);
                // Try to fetch the network stream
                try
                {
                    ns = tcpClient.GetStream();
                }
                catch
                {
                    Console.WriteLine("Unable to fetch the network stream, exiting thread.");
                    Environment.Exit(1);
                }
                // Print cool message.
                Console.WriteLine("Network stream fetched.");
                // Declare receive and send buffer and some other stuff.
                byte[] receiveBuffer = new byte[1024];
                byte[] sendBuffer;
                int bytesRead = 0;
                string message;
                bool processData = true;
                // Until someone types "exit"
                while (processData)
                {
                    Console.Write("Please enter your message: ");
                    message = Console.ReadLine();
                    if (message.ToLower() == "exit")
                    {
                        processData = false;
                        continue;
                    }
                    // Get bytes of the message.
                    sendBuffer = Encoding.ASCII.GetBytes(message);
                    // Write the data into the stream.
                    ns.Write(sendBuffer, 0, sendBuffer.Length);
                    // Read data from the stream.
                    bytesRead = ns.Read(receiveBuffer, 0, receiveBuffer.Length);
                    // Decode the data.
                    message = Encoding.ASCII.GetString(receiveBuffer, 0, bytesRead);
                    // Write it into the console window.
                    Console.WriteLine(message);
                }
                ns.Flush();
                ns.Close();
                ns.Dispose();
                tcpClient.Close();
            }
        }
    }
