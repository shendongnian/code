    public partial class Topic : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual Post LastPost { get; set; }
        public virtual Category Category { get; set; }
        public IList<Post> Posts { get; set; }
        public virtual IList<TopicTag> Tags { get; set; }
        public virtual MembershipUser User { get; set; }
        public virtual IList<TopicNotification> TopicNotifications { get; set; }
        public virtual IList<Favourite> Favourites { get; set; }
        public virtual Poll Poll { get; set; }
    }
