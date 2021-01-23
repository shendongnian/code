    public class MyAppUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Link { get; set; }
        [JsonProperty("picture")] // This renames the property to picture.
        [FacebookFieldModifier("type(large)")] // This sets the picture size to large.
        public FacebookConnection<FacebookPicture> ProfilePicture { get; set; }
       
        //[FacebookFieldModifier("limit(8)")] // This sets the size of the friend list to 8, remove it to get all friends.
        //public FacebookGroupConnection<MyAppUserFriend> Friends { get; set; }
        //[FacebookFieldModifier("limit(16)")] // This sets the size of the photo list to 16, remove it to get all photos.
        //public FacebookGroupConnection<FacebookPhoto> Photos { get; set; }
        public FacebookGroupConnection<Like> Likes { get; set; }
    }
    public class Like
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Id { get; set; }
    }
    public class FacebookPicture
    {
        public string Url { get; set; }
    }
