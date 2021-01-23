    public class Item
    {
        public Item(string letter, Brush back, Brush front)
        {
            Letter = letter;
            BackColor = back;
            FrontColor = front;
        }
        public Item(string letter, Brush back, Brush front, List<Item> items)
            : this(letter, back, front)
        {
            Items = items;
        }
        public List<Item> Items { get; set; }
        public string Letter { get; set; }
        public Brush BackColor { get; set; }
        public Brush FrontColor { get; set; }
    }
