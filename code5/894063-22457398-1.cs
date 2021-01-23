    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    
    namespace Test.SendImageClient
    {
        public class Program
        {
            static void Main(string[] args)
            {
                TcpListener tcpListener = null;
                try
                {
                    IPAddress ipadress = IPAddress.Parse("127.0.0.1");
                     tcpListener = new TcpListener(ipadress, 8000);
    
                    /* Start Listeneting at the specified port */
                    tcpListener.Start();
                    byte[] bytes = new byte[6790];
                    byte[] finalBytes;
    
                  while(true){
                      TcpClient client = tcpListener.AcceptTcpClient();
                      Console.WriteLine("Connected!");
                      NetworkStream stream = client.GetStream();
    
                      int i;
                      
                      do
                      {
                          i = stream.Read(bytes, 0, bytes.Length);
                          finalBytes = new byte[i];
                          Console.WriteLine("Size dynamically is "+i);
                          for (int n = 0; n < i; n++ )
                          {
                              finalBytes[n] = bytes[n];
                          }                     
                      }while(stream.DataAvailable);
    
                      File.WriteAllBytes("C:\\Users\\ashish\\Desktop\\newImage.jpg", finalBytes);
    
                      client.Close();
                  }                
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
                finally
                {
                    // Stop listening for new clients.
                    tcpListener.Stop();
                }
    
            }
        }
    }
