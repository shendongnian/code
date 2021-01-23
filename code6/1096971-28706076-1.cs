    public class MyDataContext : DataContext
	{
		private static MappingSource mappingSource = new AttributeMappingSource();
		public Table<Person> People;
		public Table<Item> Items;
		// pass the connection string to the base class.
		public MyDataContext() : base("DataSource=isostore:/data.sdf", mappingSource)
		{
		}
		~MyDataContext()
		{
			Dispose(false);
		}
    }
    MyDataContext db = new MyDataContext();
    // do stuff here
    db.SubmitChanges();
