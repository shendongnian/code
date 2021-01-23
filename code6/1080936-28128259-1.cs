    public class User<TId> where TId : IEquatable<TId>
    {
        public TId Id { get; set; }
    }
    
    public class Employee<TId> where TId : IEquatable<TId>
    {
        public TId Id { get; set; }
    }
