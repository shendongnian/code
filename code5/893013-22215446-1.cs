    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Web.Script.Serialization;
    
    class GuyClient
    {
         static void Main(string[] args)
         {
              String input;
      
              using (TcpClient tcpClient = 
                      new TcpClient("localhost", 16001))
              using (NetworkStream networkStream = 
                      tcpClient.GetStream())
              using (StreamReader streamReader = 
                      new StreamReader(networkStream))
              {
                   input = streamReader.ReadToEnd();
               }
      
              Console.WriteLine("Received data: " + input + "\n");
      
              JavaScriptSerializer javaScriptSerializer = 
                      new JavaScriptSerializer();
              Guy bob = javaScriptSerializer
                      .Deserialize<Guy>(input) as Guy;
              Console.WriteLine(bob.ToString());
          }
    }
