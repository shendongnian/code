    public class AccountService
    {
        private PASSEntities _context { get; set; }
        public AccountService( PASSEntities context )
        {
           this._context = context;
        }
        public User CreateAccount( string username, string password )
        {
           // implementation here
        }
