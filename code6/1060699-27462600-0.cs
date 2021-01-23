    class Program
    {
        static void Main(string[] args)
        {
    
            string json =
            @"{
                Id: 1,
    	        author_avatar: 'abc',
    	        author_avatar_small: 'small',
    	        author_avatar_medium: 'medium'
            }";
            var link = JsonConvert.DeserializeObject<Link>(json);
        }
    }
    
    public class Link
    {
        public Link(string author_avatar, string author_avatar_small, string author_avatar_medium)
        {
            AuthorAvatar = new Avatar(author_avatar, author_avatar_small, author_avatar_medium);
        }
        public int Id { get; set; }
        public Avatar AuthorAvatar { get; set; }
    }
    
    public class Avatar
    {
        public Avatar(string author_avatar, string author_avatar_small, string author_avatar_medium)
        {
            DefaultImageUri = author_avatar;
            SmallImageUri = author_avatar_small;
            MediumImageUri = author_avatar_medium;
        }
        public string DefaultImageUri { get; set; }
        public string SmallImageUri { get; set; }
        public string MediumImageUri { get; set; }
    }
