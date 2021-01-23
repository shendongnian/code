    public class EntityBase<T>
    {
        public virtual T Get(Expression<Func<T, bool>> where)
        {
            //your Logic here
        }
    
        public virtual IEnumerable<T> GetAll()
        {
          //Your Logic here
        }
    
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            //Your Logic here
        }
    }
