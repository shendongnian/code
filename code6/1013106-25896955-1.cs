    public abstract class Loot
    {
        public int Count { get; set; }
        public virtual int MaxCount { get; set; }
    }
    // Not really relevant, just implying structure, and types/interfaces you could compare
    // in your stacking validation
    public interface IConsumeable
    {
        void Consume();
    }
    public class Potion : Loot, IConsumeable
    {
        public void Consume() { }
    }
    public class Inventory : ICollection<Loot>
    {
        private int _count;
        private bool _isReadOnly;
        public IEnumerator<Loot> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Stack(Loot source, Loot target)
        {
            var availableOnTarget = target.MaxCount - target.Count;
            var amountToStack = Math.Min(availableOnTarget, source.Count);
            target.Count += amountToStack;
            source.Count -= amountToStack;
            if (target.Count == target.MaxCount && source.Count > 0)
            {
                Add(source);
            }
        }
        public void Add(Loot item)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(Loot item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(Loot[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public bool Remove(Loot item)
        {
            throw new NotImplementedException();
        }
        public int Count { get { return _count; } }
        public bool IsReadOnly { get { return _isReadOnly; } }
    }
    // This could be in Inventory, or the Player, or a gameplay manager...
    // Personally I'd implement it in the Inventory class, if there was only
    // one player with only one inventory. I'm sticking to the semantics of
    // my first version, though.
    public class Caller
    {
        public void TryAddItemToInventory<TLoot>(Inventory inventory, TLoot itemToAdd) where TLoot:Loot
        {
            var sourceType = itemToAdd.GetType();
            var stackTarget = inventory.OfType<TLoot>().First(i => i.Count < i.MaxCount);
            if (stackTarget != null)
            {
                inventory.Stack(itemToAdd, stackTarget);
            }
            else
            {
                inventory.Add(itemToAdd);
            }
            // You need to check if the inventory exists, if it has enough room to accommodate
            // the item, what happens to overflow, etc. Left all that out for brevity.
        }
    }
