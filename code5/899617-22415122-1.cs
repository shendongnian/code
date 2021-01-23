    public class From
    {
        public string name { get; set; }
        public string id { get; set; }
    }
    public class SharedWith
    {
        public string access { get; set; }
    }
    public class ResponseFolder
    {
        public string id { get; set; }
        public From from { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string parent_id { get; set; }
        public int size { get; set; }
        public string upload_location { get; set; }
        public int comments_count { get; set; }
        public bool comments_enabled { get; set; }
        public bool is_embeddable { get; set; }
        public int count { get; set; }
        public string link { get; set; }
        public string type { get; set; }
        public SharedWith shared_with { get; set; }
        public string created_time { get; set; }
        public string updated_time { get; set; }
        public string client_updated_time { get; set; }
    }
    public class FolderRequest
    {
        public List<ResponseFolder> data { get; set; }
    }
