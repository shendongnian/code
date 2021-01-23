    public class Bank
    {
        public int KeyB { get; set; }
        public string BankName { get; set; }
    }
    public class User
    {
        public int KeyU { get; set; }
        public string UserName { get; set; }
        public virtual Bank Bank { get; set; }
    }
