        public interface IMyComparer
        {
            object Comparer { get; }
        }
    
        public class IntegerClass : IMyComparer, IEqualityComparer<int>
        {
    
            public object Comparer { get { return this; } }
    
            public bool Equals(int x, int y)
            {
                throw new NotImplementedException();
    
            }
    
            public int GetHashCode(int obj)
            {
                throw new NotImplementedException();
            }
       }
       public class G<T> : ICollection<T> where T : IMyComparer
       {
         Your implementations
       }
