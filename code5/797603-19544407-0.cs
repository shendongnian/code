    public interface IEntityTypeTransform
    {
        Func<IDataRecord, object> GetDataTransform();
    }
    public abstract class EntityTypeTransform<TEntityType> : IEntityTypeTransform
        where TEntityType : class
    {
        public virtual Func<IDataRecord, TEntityType> GetDataTransform()
        {
            return this.GetDataTransformImpl();
        }
        public abstract Func<IDataRecord, TEntityType> GetDataTransformImpl();
        Func<IDataRecord, object> IEntityTypeTransform.GetDataTransform()
        {
            return this.GetDataTransform();
        }
    }
