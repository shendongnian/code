    public partial class NorthwindEntities : DbContext
    {
        public NorthwindEntities()
            : base("name=DataModel")
        {
            ((IObjectContextAdapter)this).ObjectContext.SavingChanges += ObjectContext_SavingChanges;
        }
    
        private void ObjectContext_SavingChanges(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
