    public class ViewModelWithLocalizedAttributes
    {
        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(Resources))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = "AddressIsRequired", ErrorMessageResourceType = typeof(Resources))]
        public string Address { get; set; }
    }
