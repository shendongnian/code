    public class ContactRepository : IContactRepository
    {
        private readonly AppContext context;
        public ContactRepository(string connectionString)
        {
            context = new AppContext(connectionString);
        }
        ...
