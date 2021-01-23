    public class SupplierModel
    {
        [Required(ErrorMessage = "Supplier Name cannot be blank")]
        public string Name {get; set;}
        [Required(ErrorMessage = "Supplier Age cannot be blank")]
        public string Age {get; set;}
    }
    public class ReceiverModel
    {
        [Required(ErrorMessage = "Receiver Name cannot be blank")]
        public string Name {get; set;}
        [Required(ErrorMessage = "Receiver Age cannot be blank")]
        public string Age {get; set;}
    }
