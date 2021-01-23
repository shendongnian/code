    public class ShoppingModel
    {
        [Required]
        public CartSummaryModel.DeliveryModel delivery { get; set; };
        [Required]
        public CartSummaryModel.PaymentModel payment { get; set; };
        [Required]
        public CartSummaryModel cartSummary { get; set; };
        [Required]
        public StudentModel student { get; set; };
        [Required]
        public RootObject midas { get; set; };
    
    }
