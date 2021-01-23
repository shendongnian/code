    public static class XmlPolymorphicArrayHelper
    {
        public static TResult GetItem<TIDentifier, TResult>(TResult[] items, TIDentifier[] itemIdentifiers, TIDentifier itemIdentifier)
        {
            if (itemIdentifiers == null)
            {
                return default(TResult);
            }
            var i = Array.IndexOf(itemIdentifiers, itemIdentifier);
            return i < 0 ? default(TResult) : items[i];
        }
        public static void SetItem<TIDentifier, TResult>(ref TResult[] items, ref TIDentifier[] itemIdentifiers, TIDentifier itemIdentifier, TResult value)
        {
            if (itemIdentifiers == null)
            {
                itemIdentifiers = new[] { itemIdentifier };
                items = new[] { value };
                return;
            }
            var i = Array.IndexOf(itemIdentifiers, itemIdentifier);
            if (i < 0)
            {
                var newItemIdentifiers = itemIdentifiers.ToList();
                newItemIdentifiers.Add(itemIdentifier);
                itemIdentifiers = newItemIdentifiers.ToArray();
                var newItems = items.ToList();
                newItems.Add(value);
                items = newItems.ToArray();
            }
            else
            {
                items[i] = value;
            }
        }
    }
