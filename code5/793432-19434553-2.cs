    public class Transaction
    {
        [JsonProperty("transaction_id")]
        public int Id { get; set; }
        [JsonProperty("store_id")]
        public int StoreId { get; set; }
        [JsonProperty("cashier_id")]
        public int? CashierId { get; set; }
        [JsonProperty("loyalty_account")]
        public string LoyaltyAccount { get; set; }
        [JsonProperty("transaction_time")]
        public int TransactionTime { get; set; }
        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }
        [JsonProperty("items")]
        public Dictionary<string, string> Items { get; set; }
        [JsonProperty("payments")]
        public Dictionary<string, string> Payments { get; set; }
    }
