    public class License
    {
        public License(User user)
        {
            this.User = user;
        }
        public int Id { get; set; }
        public string Key { get; set; }
        public DateTime Expirtion { get; set; }
        public virtual User User { get; set; }
    }
 
