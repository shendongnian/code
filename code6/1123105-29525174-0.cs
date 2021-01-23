    public interface IAccount
    {
        string AccountCode { get; set; }
        DateTime AccountDate { get; set; }
        string SalesCode { get; set; }
        decimal? Amount { get; set; }
    }
    public class One : IAccount 
    {
        // ...
    }
    public class Two : IAccount 
    {
        // ...
    }
    public class Three : IAccount 
    {
        // ...
    }
