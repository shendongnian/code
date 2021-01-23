    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    
    namespace Examples.System.Net
    {
        public class WebRequestGetExample
        {
            public static void Main()
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp.funet.fi/pub/standards/RFC/");
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    
                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");
    
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
    
                while (!reader.EndOfStream)
                {
                    String filename =  reader.ReadLine();
                    Console.WriteLine(filename);
                    //you now have the file name, you can use it to download this specific file
    
                }
    
                Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);
    
                reader.Close();
                response.Close();
            }
        }
    }
