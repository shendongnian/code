    public class Author
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string nickname { get; set; }
        public string url { get; set; }
        public string description { get; set; }
    }
    public class CustomFields
    {
        public List<string> tags { get; set; }
    }
    public class Post
    {
        public int id { get; set; }
        public string type { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string title_plain { get; set; }
        public string content { get; set; }
        public string excerpt { get; set; }
        public string date { get; set; }
        public string modified { get; set; }
        public List<object> categories { get; set; }
        public List<object> tags { get; set; }
        public Author author { get; set; }
        public List<object> comments { get; set; }
        public List<object> attachments { get; set; }
        public int comment_count { get; set; }
        public string comment_status { get; set; }
        public CustomFields custom_fields { get; set; }
    }
    public class YourObject
    {
        public string status { get; set; }
        public int count { get; set; }
        public int count_total { get; set; }
        public int pages { get; set; }
        public List<Post> posts { get; set; }
    }
