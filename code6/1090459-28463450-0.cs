    public class LinqDataBaseConnector : IDataBaseConnector
    {
        #region Private Variables
        public LinqDatabaseDataContext dataContext;
        #endregion
    
        public User getUser(string login, string password)
        {   
            return this.dataContext.Users.First(x => x.username == login && x.password == password);
        }
    
        public HardwareConfiguration getHardwareConfiguration(int id)
        {   
            return this.dataContext.HardwareConfigurations.First(x => x.ID == id);
        }
    }
