        private static void Main(string[] args)
        {
            var ftp = WebRequest.Create(@"ftp://ftp.microsoft.com/softlib/MSLFILES/aspwebwiz2k.zip");
            //ftp.Credentials=new NetworkCredential("anonymous","anonymous");
            var response=ftp.GetResponse();
            var stream=response.GetResponseStream();
            var ms = ToMemoryStream(stream);
            var archive = new ZipArchive(ms, ZipArchiveMode.Read);
            var entry=archive.GetEntry("file name here");
            var doc=XDocument.Load(entry.Open());
        }
        public static MemoryStream ToMemoryStream( Stream stream)
        {
            var memoryStream = new MemoryStream();
            var buffer = new byte[4096];
            while (true)
            {
                var readCount = stream.Read(buffer, 0, buffer.Length);
                if (readCount == 0)
                    break;
                memoryStream.Write(buffer, 0, readCount);
            }
            memoryStream.Position = 0;
            return memoryStream;
        }
