    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDatabaseContext _database;
        public CustomerRepository(IDatabaseContext database) {
            _database = database;
        }
        public DataTable GetDataTable() {
            DataTable dtResult;
            using (DbCommand cmd = _database.GetStoredProcCommand("spSelectAllCustomer"))
            {
                dtResult = _database.ExecuteDataSet(cmd).Tables[0];
            }
            return dtResult;
        }
    }
