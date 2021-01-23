    class Program
    {
        static void Main()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://www.tsetmc.com/tsev2/excel/MarketWatchPlus.aspx?d=0");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip,deflate";
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var output = File.Create("test.xlsx"))
            {
                stream.CopyTo(output);
            }
        }
    }
