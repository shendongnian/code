    public sealed class CarriableItem
    {
        public Fruit? Fruit { get; private set; }
        public Misc? Misc { get; private set; }
        // Only instantiated through factory methods
        private CarriableItem() {}
        public static CarriableItem FromFruit(Fruit fruit)
        {
            return new CarriableItem { Fruit = fruit };
        }
        public static CarriableItem FromMisc(Misc misc)
        {
            return new CarriableItem { Misc = misc };
        }
    }
