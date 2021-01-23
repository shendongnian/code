    public class Transaction
    {
        public int ID { get; set; }
        public string GeneratedID { get; set; }
        public DateTime TransactionDate { get; set; }
    
        public void OnSave()
        {
            GeneratedID = "hello"; //call to get the generated id from the class library
        }
    }
