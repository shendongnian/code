        static void Main(string[] args)
        {
            DB db = new DB();
            DataTable dtServers = db.GetDataTable("select * from SYS_Servers");
            string htmlCode;
            var json = "";
            using (var webClient = new System.Net.WebClient())
            {
                json = webClient.DownloadString("http://www.soyoustart.com/fr/js/dedicatedAvailability/availability-data.json");
            }
            RootObject myData = JsonConvert.DeserializeObject(json, typeof(RootObject)) as RootObject;
            String x = "moo";
        }
        public class Zone
        {
            public string availability { get; set; }
            public string zone { get; set; }
        }
        public class Availability
        {
            public string reference { get; set; }
            public Zone[] zones { get; set; }
        }
        public class RootObject
        {
            public Availability[] availability { get; set; }
        }
