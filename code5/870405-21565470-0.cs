    public static class Factory
    {
        private static Item[] items = new Item[]
        {
            // items are created here
        };
    
        public static IEnumerable<IReadableItem> Items{ get { return items; } }
        // ...
    }
