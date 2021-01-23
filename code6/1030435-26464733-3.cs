    public interface IGenericSaveRepository
        {
            void Save<TEntity>(int id, ICollection<TEntity> entities) where TEntity : class;
        }
    
    
        public class GenericSaveRepository<TEntity> where TEntity : class
        {
            private UnitofWork<TEntity> _unitofWork;
            private NaijaSchoolsContext _context;
            public GenericSaveRepository(NaijaSchoolsContext context)
            {
                _context = context;
                _unitofWork = new UnitofWork<TEntity>(_context);
            }
            public void Save(int id, ICollection<TEntity> entities)
            {
                foreach (var entity1 in entities)
                {
                    
                }
            }
        }
    
        public class UnitofWork<T>
        {
            public UnitofWork(NaijaSchoolsContext context)
            {
                throw new NotImplementedException();
            }
        }
    
        internal interface IUnitofWork<T>
        {
        }
    
        public class NaijaSchoolsContext
        {
        }
    
        public class GenericRepository<T>
        {
            protected GenericRepository(NaijaSchoolsContext context)
            {
                throw new NotImplementedException();
            }
        }
    
        public class Rating 
        {
        }
    
        public class School
        {
        }
