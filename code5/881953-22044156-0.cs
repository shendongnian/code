        class CancellableActionBlock<T>
        {
            private class Item
            {
                public T Data { get; private set; }
                public bool ShouldProcess { get; set; }
                public Item(T data)
                {
                    Data = data;
                    ShouldProcess = true;
                }
            }
            private readonly ActionBlock<Item> actionBlock;
            private readonly ConcurrentDictionary<Item, bool> itemSet;
            public CancellableActionBlock(Action<T> action)
            {
                itemSet = new ConcurrentDictionary<Item, bool>();
                actionBlock = new ActionBlock<Item>(item =>
                {
                    bool ignored;
                    itemSet.TryRemove(item, out ignored);
                    if (item.ShouldProcess)
                    {
                        action(item.Data);
                    }
                });
            }
            public bool Post(T data, bool cancelAllPreviousPosts = false)
            {
                if (cancelAllPreviousPosts)
                {
                    foreach (var item in itemSet.Keys)
                    {
                        item.ShouldProcess = false;
                    }
                    itemSet.Clear();
                }
                var newItem = new Item(data);
                itemSet.TryAdd(newItem, true);
                return actionBlock.Post(newItem);
            }
            // probably other members that wrap actionBlock members,
            // like Complete() and Completion
        }
