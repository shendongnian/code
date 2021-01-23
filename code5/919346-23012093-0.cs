    public class EbayCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID
        {
            get { return base.ID; }
            set { base.ID = value; }
        }
        public string Name { get; set; }      
        // ... some other properties
    }
