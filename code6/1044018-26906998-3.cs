    public class Customer
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }
    
            public class Bank
            {
                public int CustomerId { get; set; }
                public int Id { get; set; }
            }
    
            public class BankTransaction
            {
                public int BankId { get; set; }
                public int MoneyIn { get; set; }
                public int MoneyOut { get; set; }
            }
