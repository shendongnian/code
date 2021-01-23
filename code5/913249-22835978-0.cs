        private static string[,] Rss_read(string connection)
        {
            WebRequest feedRqst = WebRequest.Create(connection);
            WebResponse feedRspns = feedRqst.GetResponse();
            Stream rssStream = feedRspns.GetResponseStream(); // Returning the feed stream;
            StreamReader sr = new StreamReader(rssStream);
            while (!sr.EndOfStream)
            {
                //Do some logic
            }
        }
