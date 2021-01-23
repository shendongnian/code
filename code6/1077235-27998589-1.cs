    public class CurrencyViewModel
        {
            [Key]
            public Int32 CURRENCY_Id { get; set; }
            [Required(ErrorMessage="Currency Name is required")]
            public string CURRENCY_NAME { get; set; }
            [Required(ErrorMessage="Currency Description is required")]
            public string CURRENCY_DESC { get; set; }
            [Required(ErrorMessage = "Currency Symbole is Required")]
            public string CURRENCY_SYMBOLE { get; set; }
        }
