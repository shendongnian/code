    public class BaseRepository<T, U> where T : class
    {
        public virtual IEnumerable<U> GetAll()
        {
            using (ApplicationEntities context = new ApplicationEntities())
            {
                IEnumerable<T> models = context.Set<T>();
                return Mapper.Map<IEnumerable<T>, IEnumerable<U>>(models);                
            }
        }
    }
