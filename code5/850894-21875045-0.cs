        public class CustomerModel
        {
            [Required]
            [Display(Name = "Customer Name")]
            public string CustomerName { get; set; }
        
            [Required]
            public string Company { get; set; }
        
            [Required]
            public ContactModel ContactModel {get;set;}
            [Required]
            [Display(Name="Contact Details")]
            public List<ContactModel> Contacts { get; set; }
        }   
