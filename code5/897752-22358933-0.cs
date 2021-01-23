    public class PagedMalicious : Shared.Paged
    {
        public IEnumerable<MaliciousSmall> MaliciousCode { get; set; }
        public PagedMalicious()
        {
            MaliciousCode = new List<MaliciousSmall>();
        }
        // other private methods that add to MaliciousCode
    }
