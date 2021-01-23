    public class SFTDBEntities : DbContext
    {
        public SFTDBEntities ()
            : base(ContextHelper.CreateConnection("Connection string"), true)
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
        }
    }
