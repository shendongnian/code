    public interface IAuditable
    {
        public DateTime LastUpdated { get; set; }
    }
    public class MyEntity : IAuditable
    {
        ...
        public DateTime LastUpdated { get; set; }
    }
