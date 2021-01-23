    public class TransformedData
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Description { get; set; }
        public double CurrentYear { get; set; }
        public double RenameThisProperty
        {
            get
            {
                return CurrentYear + Children.Sum(child => child.RenameThisProperty);
            }
        }
        public List<TransformedData> Children { get; set; }
    
        public TransformedData()
        {
            this.Children = new List<TransformedData>();
        }
    }
