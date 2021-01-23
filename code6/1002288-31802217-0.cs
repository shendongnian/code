    var settings = new JsonSerializerSettings
                               {
                                   EqualityComparer = new DefaultEqualityComparer(),
                               };
    
    public class DefaultEqualityComparer : IEqualityComparer
        {
            public bool Equals(object x, object y)
            {
                return ReferenceEquals(x, y);
            }
    
            public int GetHashCode(object obj)
            {
                return obj.GetHashCode();
            }
        }
