    public abstract class Loot
    {
        public int Count { get; set; }
        public virtual int MaxCount { get; set; }
    }
    public class Inventory : ICollection<Loot>
    {
        public void Stack(Loot source, Loot target)
        {
            var availableOnTarget = target.MaxCount - target.Count;
            var amountToStack = Math.Min(availableOnTarget, source.Count);
            target.Count += amountToStack;
            source.Count -= amountToStack;
            if (target.Count == target.MaxCount && source.Count > 0)
            {
                this.Add(source);
            }
        }
        // ICollection implementation...
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
