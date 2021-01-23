    class Program
    {
       static byte[] Key = new byte[] { 0x02, 0x02, 0x01, 0x03, 0x02, 0x32,
          0x51, 0x13, 0x02, 0x02, 0x01, 0x03, 0x02, 0x32, 0x51, 0x13, 
          0x02, 0x02, 0x01, 0x03, 0xA2, 0x33, 0x53, 0xF3, 0xE2, 0xB2,
          0xA1, 0x93, 0x32, 0x52, 0x53, 0x83 };
       static byte[] IV = new byte[] { 0x44, 0x82, 0xF1, 0x03, 0xA2, 0x3D,
          0x51, 0x13, 0x42, 0x02, 0x01, 0x03, 0x02, 0x32, 0x51, 0x13 };
       static SymmetricAlgorithm Algo = new RijndaelManaged();
       static void Main(string[] args)
       {
          Algo.KeySize = 256;
          Algo.Padding = PaddingMode.PKCS7;
          Algo.Key = Key;
          Algo.IV = IV;
          var svrTask = RunServer();
          RunClient();
          svrTask.Wait();
       }
      static async Task RunServer()
      {
         byte[] resp = new byte[2048];
         var listener = new TcpListener(4567);
         
         listener.Start();
         var client = await listener.AcceptTcpClientAsync();
         using (var stream = client.GetStream())
         {
            // should read while DataAvailable
            var bytes = stream.Read(resp, 0, resp.Length);
            Array.Resize<byte>(ref resp, bytes);
            
            string resp_str = DecryptArray(resp);
            var data = "Server Received: " + resp_str;
            Console.WriteLine(data);
            byte[] enc_resp = EncryptString(data);
            stream.Write(enc_resp, 0, enc_resp.Length);
         }
         client.Close();
         listener.Stop();
      }
      static void RunClient()
      {
         byte[] resp = new byte[2048];
         using (var client = new TcpClient("localhost", 4567))
         using (var stream = client.GetStream())
         {
            Console.WriteLine("Client will send: ");
            var data = Console.ReadLine();
            byte[] enc_msg = EncryptString(data);
            stream.Write(enc_msg, 0, enc_msg.Length);
            // should read while DataAvailable
            var bytes = stream.Read(resp, 0, resp.Length);
            Array.Resize<byte>(ref resp, bytes);
            string response = DecryptArray(resp);
            Console.WriteLine("Client received: " + response);
         }
      }
      static byte[] GetBytes(string str)
      {
         byte[] bytes = new byte[str.Length * sizeof(char)];
         System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
         return bytes;
      }
      static string GetString(byte[] bytes)
      {
         char[] chars = new char[bytes.Length / sizeof(char)];
         System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
         return new string(chars);
      }
      private static byte[] EncryptString(string stringValue)
      {
         return TransformData(GetBytes(stringValue), true);
      }
      private static string DecryptArray(byte[] arrayValue)
      {
         return GetString(TransformData(arrayValue, false));
      }
      private static byte[] TransformData(byte[] dataToTransform, bool enc)
      {
         byte[] result = new byte[0];
         if (dataToTransform != null && dataToTransform.Length > 0)
         {
            try
            {
               using (var transform = (enc) ? Algo.CreateEncryptor() :
                 Algo.CreateDecryptor())
               {
                  result = transform.TransformFinalBlock(
                     dataToTransform, 0, dataToTransform.Length);
               }
            }
            catch (Exception) { /* Log this */ }
         }
         return result;
      }
    }
