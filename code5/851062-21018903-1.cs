    using System;
    using System.Net.Sockets;
    namespace tcpclienttest
    {
      class Program
      {
        static byte[] GetData(string server, string pageName, int byteCount, out int     actualByteCountRecieved)
        {
          const int port = 80;
          TcpClient client = new TcpClient(server, port);
          string fullRequest = "GET " + pageName + " HTTP/1.1\nHost: " + server + "\n\n";
          byte[] outputData = System.Text.Encoding.ASCII.GetBytes(fullRequest);
      
          NetworkStream stream = client.GetStream();
          stream.Write(outputData, 0, outputData.Length);
      
          byte[] inputData = new Byte[byteCount];
      
          actualByteCountRecieved = stream.Read(inputData, 0, byteCount);
      
          // If you want the data as a string, set the function return type to a string
          // return 'responseData' rather than 'inputData'
          // and uncomment the next 2 lines
          //string responseData = String.Empty;
          //responseData = System.Text.Encoding.ASCII.GetString(inputData, 0, actualByteCountRecieved);
      
          stream.Close();
          client.Close();
      
          return inputData;
        }
        static void Main(string[] args)
        {
          int actualCount;
          const int requestedCount = 1024;
          const string server = "myserver.mydomain.com"; // NOTE: NO Http:// or https:// bit, just domain or IP
          const string page = "/folder/page.ext";
          byte[] myPartialPage = GetData(server, page, requestedCount, out actualCount);
        }
      }
    }
