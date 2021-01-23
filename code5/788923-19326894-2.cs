    public class ADataObjectContext : DataObjectBase<ADataObject>
    {
        public ADataObjectContext(IRepository repository)
            : base(repository)
        {
        }
    }
