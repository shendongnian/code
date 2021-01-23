      public interface IEntitiesFactory
      {
         Entities Create();
      }
      public interface ILog
      {
         void LogLine(TraceLevel level, string message);
      }
      class Authenticator : IAuthenticator
      {
         private readonly IEntitiesFactory _entitiesFactory;
         private readonly ILog _log;
         public Authenticator(IEntitiesFactory entitiesFactory, ILog log)
         {
            _entitiesFactory = entitiesFactory;
            _log = log;
         }
         public string UserId { get; set; }
         public string Password { get; set; }
         public UserModel User { get; private set; }
         public bool ValidateUser()
         {
            if (string.IsNullOrEmpty(UserId))
               return false;
            if (string.IsNullOrEmpty(Password))
               return false;
            using (var db = _entitiesFactory.Create())
            {
               MD5 md5 = MD5.Create();
               byte[] inputBytes = Encoding.ASCII.GetBytes(this.Password);
               byte[] hash = md5.ComputeHash(inputBytes);
               string md5Hash = BitConverter.ToString(hash).ToUpper().Replace("-", string.Empty);
               var query = from u in db.Users
                           where u.UserId.ToUpper().Trim() == this.UserId.ToUpper()
                           where u.CPassword.Trim() == md5Hash
                           select u;
               this.User = query.FirstOrDefault();
            }
            if (this.User == null)
            {
               _log.LogLine(TraceLevel.Verbose, string.Format("Authentication failed for user '{0}'", this.UserId));
               return false;
            }
            else
            {
               _log.LogLine(TraceLevel.Verbose, string.Format("Successfully authenticated user '{0}'", this.UserId));
               return true;
            }
         }
