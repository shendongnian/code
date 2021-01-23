     public class BuyBitcoinViewModel
            {
                public PurchaseViewModel PurchaseViewModel { get; set; }
                public string Name { get; set; }
                public string Email { get; set; }
                public string Phone { get; set; }
            }
    
            public class PurchaseViewModel
            {
                public string PurchaseAmount { get; set; }
                public string BitcoinAddress { get; set; }
            }
