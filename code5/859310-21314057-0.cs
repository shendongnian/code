    public class ItemsModel
    {
        // The list to be displayed in the <select>
        public List<string> itemsList { get; set; }
        // The list of selected items
        public List<string> items { get; set; }
        public ItemsModel()
        {
            this.itemsList = new List<string>();
            this.items = new List<string>();
        }
    }
