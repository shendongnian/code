    public class User
    {
        private string userId;
        public string UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
                OnPropertyChanged("UserImageUrl");
            }
        }
        public string UserImageUrl
        {
            get { return string.Format("http://www.aaaa.com/{0}.jpg", userId); }
        }
    }
