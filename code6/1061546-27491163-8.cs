    namespace StackOverflowPlayground
    {
        class JesusPlayground
        {
            public JesusPlayground()
            {
                var auditableRepo = new AuditableRepo();
                auditableRepo.GetUsuarioById(1);
                var otherRepo = new OtherRepo();
                //otherRepo. (does not have GetUsuarioById
                var auditableRepoNotUsingTheActualClass = new GenericRepository<IAuditable>();
                auditableRepoNotUsingTheActualClass.GetUsuarioById(1); //still works!
            }
        }
        public static class Extensions
        {
            public static IEnumerable<IAuditable> GetUsuarioById(this IRepository<IAuditable> repository, int id)
            {
                return repository.FindBy(audible => audible.Id == id);
            }
        }
        public class OtherRepo : IRepository<OtherType>
        {
            public IEnumerable<OtherType> FindBy(Expression<Func<OtherType, bool>> expr)
            {
                throw new NotImplementedException();
            }
        }
        public class OtherType
        {
        }
        public interface IAuditable
        {
            int Id { get; set; }
        }
        public interface IRepository<T>
        {
            IEnumerable<T> FindBy(Expression<Func<T, bool>> expr);
        }
        public class GenericRepository<T> : IRepository<T>
        {
            public IEnumerable<T> FindBy(Expression<Func<T, bool>> expr)
            {
                throw new NotImplementedException();
            }
        }
        class AuditableRepo : IRepository<IAuditable>
        {
            public IEnumerable<IAuditable> FindBy(Expression<Func<IAuditable, bool>> expr)
            {
                throw new NotImplementedException();
            }
        }
    }
