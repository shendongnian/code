    [DataContract]
    public class JsonRoot
    {
    	[DataMember(Name="data")]
    	public List<Post> Data { get; set; }
    }
    
    [DataContract]
    public class Post
    {
    	[DataMember(Name="id")]
    	public string Id { get; set; }
    	[DataMember(Name="from")]
    	public From From { get; set; }
    	[DataMember(Name="message")]
    	public string Message { get; set; }
    	[DataMember(Name="picture")]
    	public string Picture { get; set; }
    	[DataMember(Name="likes")]
    	public DataContainer Likes { get; set; }
    }
    
    [DataContract]
    public class DataContainer
    {
    	[DataMember(Name="data")]
    	public List<Like> Data { get; set; }
    }
    
    [DataContract]
    public class From
    {
    	[DataMember(Name="category")]
        public string Category { get; set; }
    	[DataMember(Name="name")]
        public string Name { get; set; }
    	[DataMember(Name="id")]
        public string Id { get; set; }
    }
    
    [DataContract]
    public class Like
    {
    	[DataMember(Name="id")]
        public string Id { get; set; }
    	[DataMember(Name="name")]
        public string Name { get; set; }
    }
