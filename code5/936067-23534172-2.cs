    struct Item
    {
        public int a;
        public string b;
    
        public Item(int a, string b)
        {
            this.a = a;
            this.b = b;
        }
    };
    Item[] items = new[] {
        new Item( 12, "Hello" ),
        new Item( 13, "Bye" )
    };
