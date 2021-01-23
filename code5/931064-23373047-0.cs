    public partial class herstellers
    {
        public herstellers()
        {
            this.marken = new ObservableCollection<marke>();
        }
    
        public int h_id { get; set; }
        public string h_name { get; set; }
    
        public virtual ICollection<marke> marken { get; set; }
    }
