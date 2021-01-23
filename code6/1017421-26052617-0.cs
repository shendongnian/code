    abstract class Item { }
    
    interface ILetters
    {
        Item SearchItem(Item item);
    }
    abstract class Letters<T> : ILetters
        where T : Item
    {
        public Item SearchItem(Item item)
        {
            return SearchItemOverride((T)item);
        }
        protected abstract Item SearchItemOverride(T item);
    }
    class ItemA : Item { }
    class ClassA : Letters<ItemA> 
    {
        protected override Item SearchItemOverride(ItemA item)
        {
            // ...
        }
    }
