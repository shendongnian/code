    [JsonConverter(typeof(NullStringConverter))]
    public class User
    {
       public int Id;
       public Guid? Guid { get; set; }
       public float Height { get; set; }
       public List<Friend> Friends { get; set; }
       public string FirstName { get; set; }
       public double? Credit { get; set; }
       public DateTimeOffset CreateDate { get; set; }
       public DateTimeOffset? LastUpdate { get; set; }
       public DateTime? DateOfBirth { get; set; }
       public long FriendCount { get; set; }
       public string[] FriendIds { get; set; }
    }
