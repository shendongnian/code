    public class PaymentBillViewModel
        {
            public int BillId { get; set; }
            public int PaymentId { get; set; }
            public string InvoiceNumber { get; set; }
            public Int64 Amount { get; set; }
            public int? NewPaymentId { get; set; }
            public virtual NewPayment RelPayment { get; set; }
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LstName { get; set; }    
            public DateTime PaymentDate { get; set; }
            public Int64 ProvisionNumber { get; set; }
            public Int64 CreditCardNumber { get; set; }
            public int ExpMonth { get; set; }
            public int ExpYear { get; set; }
            public int Cv2 { get; set; }
            public Int64 Amount { get; set; }
            public string UserId { get; set; }
            public string CustomerNote { get; set; }
    
        }
