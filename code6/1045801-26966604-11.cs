    public class WritingAppModel
    {
        // ... other existing properties
    
        [Required(ErrorMessage = "Price is Required.")]
        [Range(0.01, 10000.00, ErrorMessage = "Your quote is not complete because you haven't completed all of the steps.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }
    
        public string UnFormattedPrice
        {
            get
            {
                return this.Price.ToString();
            }
        }
    }
