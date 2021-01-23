    public class Table1
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public DateTime DOB { get; set; }
    }
    
    public class Table1Repository
    {
        private readonly MyEntities _context;
    
        public Table1Repository()
        {
            this._context = new MyEntities();
        }
    
        public IQueryable<Table1> Get()
        {
            return this._context.Table1; // very simple linq statement - in effect your "Select * from table1"
        }
    
        public IQueryable<Table1> GetById(DateTime dob)
        {
            return this._context.Table1.Where(w => w.DOB == dob); // pulls records with a dob matching param
        }
