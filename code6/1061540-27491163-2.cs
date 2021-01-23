    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    
    namespace StackOverflowPlayground
    {
        class JesusPlayground
        {
            public JesusPlayground()
            {
                var audibleRepo = new AudibleRepo();
                audibleRepo.GetUsuarioById(1);
    
                var otherRepo = new OtherRepo();
                //otherRepo. (does not have GetUsuarioById)
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
            public static IEnumerable<IAudible> GetUsuarioById(this IRepository<IAudible> repository, int id)
            {
                return repository.FindBy(audible => audible.Id == id);
            }
        }
    
        public interface IAudible
        {
            int Id { get; set; }
        }
    
        public interface IRepository<T>
        {
            IEnumerable<T> FindBy(Expression<Func<T, bool>> expr);
        }
    
        class AudibleRepo : IRepository<IAudible>
        {
            public IEnumerable<IAudible> FindBy(Expression<Func<IAudible, bool>> expr)
            {
                throw new NotImplementedException();
            }
        }
    }
