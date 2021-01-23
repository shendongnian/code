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
        public static class Extensions
        {
            public static IEnumerable<IAuditable> GetUsuarioById(this IRepository<IAuditable> repository, int id)
            {
                return repository.FindBy(audible => audible.Id == id);
            }
        }
        public interface IAuditable
        {
            int Id { get; set; }
        }
        public interface IRepository<T>
        {
            IEnumerable<T> FindBy(Expression<Func<T, bool>> expr);
        }
        class AuditableRepo : IRepository<IAuditable>
        {
            public IEnumerable<IAuditable> FindBy(Expression<Func<IAuditable, bool>> expr)
            {
                throw new NotImplementedException();
            }
        }
    }
