    public class ProductsViewModel
    {
        .....
        public string Category { get; set; } // see notes below
        [Display(Name = "Category")]
        [Required(ErrorMessage = "The Category is required.")]
        public int CategoryID { get; set; }
        public SelectList CategoryList { get; set; }
    }
