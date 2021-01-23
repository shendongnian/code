    public interface IResellerClubClient {
        string RequestJson(string url);
    }
    public class ResellerClubClient : IResellerClubClient {
        // implement your methods here 
    }
    public ResellerClubApi : IResellerClubApi {
        private readonly IResellerClubClient client;
        // Pass the client as dependency, either manually or using Dependency framework of your choice
        public ResellerClubApi(IResellerClubClient client) {
            this.client = client;
        }
        public List<string> SuggestNames(string domainName) {
            var jsonString = this.client.RequestJson("http://example.com/domains/?name="+domainName);
            // decode it and do something with it
        }
    }
