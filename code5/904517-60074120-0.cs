    public interface IBuyService
    {
        Task<Buy> GetBuyItems();
    }
    public class BuyService: IBuyService
    {
        private readonly HttpClient _httpClient;
        public BuyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Buy> GetBuyItems()
        {
            var uri = "Uri";
            var responseString = await _httpClient.GetStringAsync(uri);
            var buy = JsonConvert.DeserializeObject<Buy>(responseString);
            return buy;
        }
    }
