    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            await TimeParsing("-33.8674869", "151.20699020000006");
        }
        public async Task TimeParsing(string lat, string lon)
        {
            var urlbeg = "http://api.geonames.org/timezone?lat=";
            var urlmid = "&lng=";
            var urlend = "&username=dheeraj_kumar";
            var downloader = new WebClient();
            var uri = new Uri(urlbeg + lat + urlmid + lon + urlend, UriKind.Absolute);
            downloader.DownloadStringCompleted += TimeDownloaded;
            var test = await downloader.DownloadStringTaskAsync(uri);
            Console.WriteLine(test);
        }
        private void TimeDownloaded(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Result == null || e.Error != null)
            {
                Console.WriteLine("Invalid");
            }
            else
            {
                var document = XDocument.Parse(e.Result);
                var data1 = from query in document.Descendants("timezone")
                            select new Country
                            {
                                CurrentTime = (string)query.Element("time"),
                            };
                foreach (var d in data1)
                {
                    Console.WriteLine(d.CurrentTime);
                }
            }
        }
    }
    internal class Country
    {
        public string CurrentTime { get; set; }
    }
}
