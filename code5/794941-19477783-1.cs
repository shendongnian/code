    public class SaveCartMvcViewModel
    {
        public SaveCustomerMvcViewModel Customer { get; set; }
    
        [Required(ErrorMessage = "VAT mandatory.")]
        public int VatId { get; set; }
    }
