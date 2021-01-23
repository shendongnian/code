    public class ListItem {
        public string Content { get; set; }
    }
    
    public class ListOfItems {
             public int Id { get; set; }
             public IList<ListItem> Items { get; set; }
    }
