    class Program
    {
        static void Main( string[] args )
        {
            List<Item> items = new List<Item>();
            items.Add( new Item( "A" ) );
            items.Add( new Item( "A" ) );
            items.Add( new Item( "B" ) );
            items.Add( new Item( "C" ) );
            items = items.Distinct().ToList();
        }
    }
    public class Item
    {
        string Name { get; set; }
        public Item( string name )
        {
            Name = name;
        }
        public override bool Equals( object obj )
        {
            return Name.Equals((obj as Item).Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
