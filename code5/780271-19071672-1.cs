    public class Server
    {
        public List<string> serverNames = new List<string>();
        public List<object> urlList = new List<object>();
        public string[][] urlArr = new string[1][];
        public Server()
        {
        }
        public Server(string nm)
        {
            serverNames.Add(nm);
        }
        public void setName(string newName)
        {
            serverNames.Add(newName);
        }
        public void addUrl(string newUrl)
        {
            Server.Url url = new Server.Url(newUrl);
            urlList.Add(url);
            url.SetStatus(false);
        }
    }
    public class Url
    {
        public string url;
        public bool Status { get; set; }
        public Url()
        {
        }
        public Url(string URL)
        {
            url = URL;
        }
    }
