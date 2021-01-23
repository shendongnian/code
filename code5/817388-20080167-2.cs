            public interface IHaveId<T>
            {
                T Id { get; set; }
            }
    
            public class User : IHaveId<int>
            {
                public int Id { get; set; }
                public virtual List<Right> Rights { get; set; }
            }
    
            public class Right : IHaveId<int>
            {
                public int Id { get; set; }
    
                public RightType RightType { get; set; }
            }
    
            public enum RightType : byte
            {
                Own,
                Copy,
                Delete
            }
    
            public static IEnumerable<TKey> GetChildIds<TParent,TChild,TKey>(IQueryable<TParent> src, TKey parentId, Expression<Func<TParent,IEnumerable<TChild>>> childSelector)
                where TParent : IHaveId<TKey>
                where TChild : IHaveId<TKey>
                where TKey : struct, IEquatable<TKey>
    
            {
                var result = src
                    .Where(parent => parentId.Equals(parent.Id))
                    .SelectMany(childSelector)
                    .Select(child => child.Id);
                
                return result;
            }
    //sample usage
    //var ids = GetChildIds<User,Right,int>(_context.DbSet<User>(), user=>user.Rights).ToList();
