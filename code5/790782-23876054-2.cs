    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Cache;
    using System.Text;
    
    namespace UploadSvcConsumer
    {
        class Program
        {
            static void Main(string[] args)
            {
                //WebClient client = new WebClient();
                //client.UploadData("http://localhost:1208/UploadService.svc/Upload",)
                //string path = Path.GetFullPath(".");
                byte[] bytearray=null ;
                //throw new NotImplementedException();
                Stream stream =
                    new FileStream(
                        @"C:\Image\hanuman.jpg"
                        FileMode.Open);
                    stream.Seek(0, SeekOrigin.Begin);
                    bytearray = new byte[stream.Length];
                    int count = 0;
                    while (count < stream.Length)
                    {
                        bytearray[count++] = Convert.ToByte(stream.ReadByte());
                    }
    
                string baseAddress = "http://localhost:1208/UploadService.svc/";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(baseAddress + "Upload");
                request.Method = "POST";
                request.ContentType = "text/plain";
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                Stream serverStream = request.GetRequestStream();
                serverStream.Write(bytearray, 0, bytearray.Length);
                serverStream.Close();
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    int statusCode = (int)response.StatusCode;
                    StreamReader reader = new StreamReader(response.GetResponseStream());
    
                }
    
            }
        }
    }
