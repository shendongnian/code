    public class Meta
    {
        public int code { get; set; }
        public string status { get; set; }
        public string method_name { get; set; }
    }
    
    public class Photos
    {
        public int total_count { get; set; }
    }
    
    public class Storage
    {
        public int used { get; set; }
    }
    
    public class Stats
    {
        public Photos photos { get; set; }
        public Storage storage { get; set; }
    }
    
    public class From
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<object> external_accounts { get; set; }
        public string email { get; set; }
        public string confirmed_at { get; set; }
        public string username { get; set; }
        public string admin { get; set; }
        public Stats stats { get; set; }
    }
    
    public class ParticipateUser
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<object> external_accounts { get; set; }
        public string email { get; set; }
        public string confirmed_at { get; set; }
        public string username { get; set; }
        public string admin { get; set; }
        public Stats stats { get; set; }
    }
    
    public class ChatGroup
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string message { get; set; }
        public List<ParticipateUser> participate_users { get; set; }
    }
    
    public class Chat
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string message { get; set; }
        public From from { get; set; }
        public ChatGroup chat_group { get; set; }
    }
    
    public class Response
    {
        public List<Chat> chats { get; set; }
    }
    
    public class RootObject
    {
        public Meta meta { get; set; }
        public Response response { get; set; }
    }
