    public class ItemViewModel
    {
        public ItemViewModel()
        {
            Options = new List<Option>();
        }
        public int itemId { get; set; }
    
        [UIHint("Option")]
        public List<Option> Options { get; set; }
    }
