    public class ConnectionRepository:IConnectionRepository
    {
        private readonly DatePickerDbContext _db;
        //private readonly ISuperOfficeRepository _superOfficeRepository;
    
        public ConnectionRepository(DatePickerDbContext db)//, ISuperOfficeRepository superOfficeRepository
        {
            _db = db;
          //  _superOfficeRepository = superOfficeRepository;
        }
         public int GetConnectionId(string connectionName)
         {
            var connection = _db.Connections.Single(c => c.Name == connectionName);
            return connection.Id;
          }
    
         public bool CheckIfSuperOfficeIsConnected(string userId)
         {
            var connectionId = GetConnectionId("SuperOffice");
            var result = _db.UserConnections.Where(uc => uc.UserId == userId && uc.ConnectionId == connectionId);
            return result.Any();
         }
     }
