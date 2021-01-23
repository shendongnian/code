    using System;
    using System.IO;
    using Newtonsoft.Json;
    
    public class Transaction
    {
        [JsonProperty("visited_date")]
        public DateTime VisitedDate { get; set; }
        [JsonProperty("party_code")]
        public string PartyCode { get; set; }
        [JsonProperty("response")]
        public string Response { get; set; }
        [JsonProperty("response_type")]    
        public string ResponseType { get; set; }
        [JsonProperty("time_stamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("trans_id")]
        public string TransactionId { get; set; }
        [JsonProperty("total_amount")]    
        public double TotalAmount { get; set; }
        [JsonProperty("discount")]
        public double Discount { get; set; }
    }
    
    public class TransactionWrapper
    {
        [JsonProperty("trn")]
        public Transaction Transaction { get; set; }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            string json = "{\"trn\":{\"visited_date\":\"2015-04-05\",\"party_code\":\"8978a1bf-c88b-11e4-a815-00ff2dce0943\",\"response\":\"Reason 5\",\"response_type\":\"NoOrder\",\"time_stamp\":\"2015-04-05 18:27:42\",\"trans_id\":\"8e15f00b288a701e60a08f968a42a560\",\"total_amount\":0.0,\"discount\":0.0}}";
            var wrapper = JsonConvert.DeserializeObject<TransactionWrapper>(json);
            Console.WriteLine(wrapper.Transaction.PartyCode);
        }
    }
