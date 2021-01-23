    [DataContract]
    public class Expense
    {
        [DataMember(Name = "account_name")]
        public string Account_Name { get; set; }
    
        [DataMember(Name = "paid_through_account_name")]
        public string Paid_Through_Account_Name { get; set; } //string type
    }
