    class Program
    {
        static void Main(string[] args)
        {
            var credentials = new Credentials("My User Name", "some password");
            var AD = new ArchiveData(credentials);
            Console.Write(AD.UserId);
            Console.Write(AD.Password);
        }
    }
    public class ArchiveData
    {
        private readonly Credentials myCredentials;
        public string UserData { get; set; }
        public string UserId
        {
            get
            {
                return this.myCredentials.UserId;
            }
        }
        public string Password
        {
            get
            {
                return this.myCredentials.Password;
            }
        }
        public ArchiveData(Credentials credentials)
        {
            if (credentials == null)
            throw new ArgumentNullException();
            this.myCredentials = credentials;
        }
    }
    public class Credentials
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public Credentials(string userId, string password)
        {
            this.UserId = userId;
            this.Password = password;
        }
    }
