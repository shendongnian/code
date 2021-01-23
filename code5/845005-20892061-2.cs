    public class QueryDetailsResult : IPortfolio
    {
        public string SiteName { get; set; }
    }
    public interface IPortfolio
    {
        string SiteName { get; set; }
    }
