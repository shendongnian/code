    public class TwitterUserInfo
    {
        public FriendCollection Friends { get; get; }
        public FollowerCollection Followers { get; set; }
        public FavoriteCollection Favorites { get; set; }
        public TwitterUserInfo(TwitterUser user)
        {
            Friends = user.GetFriends(20);
            Followers = user.GetFollowers(20);
            Favorites = user.GetFavorites(20);
        }
    }
