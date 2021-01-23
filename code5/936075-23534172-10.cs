    class Items : List<Item>
    {
        public void Add(int a, string b)
        {
            Add(new Item(a, b));
        }
    }
