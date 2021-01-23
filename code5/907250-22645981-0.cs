    public ViewModel 
    {
        public int CustomerID { get; set; }
        public IList<SelectListItem> Customers { get; set; }
        public ViewModel() {
            this.Customers = new List<SelectListItem>();
        }
    }
