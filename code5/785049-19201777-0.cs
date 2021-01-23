    // Overload StockItem<T> by generic arity
    public static class StockItem
    {
        public static StockItem<T> Of(T item)
        {
            return new StockItem<T>(item);
        }
    }
