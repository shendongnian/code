    public class MyContext : DbContext
    {
        public MyContext()
            : base("DefaultConnection")
        {            
        }
		
        public IDbSet<BaseTable> BaseTables { get; set; }
        public IDbSet<DerivedWithRelation> DerivedWithRelations { get; set; }
        public IDbSet<DerivedWithoutRelation> DerivedWithoutRelations { get; set; }
    }
