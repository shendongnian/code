    class TransactionPagedResult
    {
        public IEnumerable<Transaction> Transactions { get; set; }
    }
    class Transaction
    {
        public string Id { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
    class InternalTransaction : Transaction
    {
        public User Recipient { get; set; }
    }
    class ExternalTransaction : Transaction
    {
        public string Hsh { get; set; }
        [JsonProperty("recipient_address")]
        public string RecipientAddress { get; set; }
    }
    class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
