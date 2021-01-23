    public static class Factories
    {
        private static ItemFactory _itemFactory = new ItemFactory();
        public static ItemFactory ItemFactory { get { return _itemFactory; } }
    }
