    namespace WpfApplication1
    {
        public class ViewModel
        {
            public ViewModel()
            {
                this.items = new List<Item> {
                new Item("13.4"),
                new Item("22.3")};
            }
    
            public List<Item> Items
            {
                get { return this.items; }
            }
    
            public string CurrencyUnit
            {
                get { return "$"; }
            }
    
            private List<Item> items;
        }
    }
