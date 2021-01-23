    public class Expense
    {
        public string chart_of_accounts_id { get; set; }
        public string account_name { get; set; }
        public decimal amount { get; set; }
        public string entry_type { get; set; }
        public string business_id { get; set; }
        public int account_category { get; set; }
    }
    public class ExpensesResponse
    {
        [JsonProperty(PropertyName = "")] 
        public ExpensesResponseContent Content { get; set; }
    }
    public class ExpensesResponseContent
    {
        public List<List<Expense>> Expense { get; set; }
         
    }
    public class Messages
    {
        public string msgs { get; set; }
        public string errs { get; set; }
    }
    public class RootObject
    {
        public ExpensesResponse response { get; set; }
        public Messages messages { get; set; }
    }
