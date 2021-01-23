    class UserTimeLine: IEquatable<UserTimeLine>
    {
        public int NewsId { get; set; }
        /* other properties omitted for brevity */
        public bool Equals(UserTimeLine other) {
            return this.NewsId == other.NewsId;
        }
    }
