    public static void GetDateTimestampOnServer (Uri serverUri)
        {
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                throw new ArgumentException("Scheme Must match Ftp Uri Scheme");
            }
        
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create (serverUri);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse ();
            Console.WriteLine ("{0} {1}",serverUri,response.LastModified);
        }
