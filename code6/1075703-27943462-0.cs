    public abstract class BaseDTO<T> where T : BaseEntity
    {
        protected abstract void ConvertFromEntity(T entity);
        public abstract T ConvertToEntity();
    }
    
    public class DTODocNum : BaseDTO<DocNum> { ... }
