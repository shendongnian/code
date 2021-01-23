    public class Transaction
    {
        public string ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public void OnSave()
        {
            ID = Guid.NewGuid().ToString(); //call to class library
        }
    }
