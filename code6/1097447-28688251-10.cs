    public class BusinessValidator<T> : IBusinessValidator<T> where T : IEntity
    {
        public void Validate(T entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ArgumentNullException(entity.Name);
        }
    }
