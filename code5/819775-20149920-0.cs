        class ItemFactory
        {
            private static readonly Dictionary<string, MyClass> knownItems = new Dictionary<string, MyClass>
            {
                {"bracelet", new MyClass("bracelet", "male", 0, true)},
                {"ring", new MyClass("ring","female",8,false)}
            };
            
            public MyClass createItemByType(string itemType)
            {
                if (knownItems.ContainsKey(itemType))
                    return (knownItems[itemType]); 
                // default behavior if an item isn't found.
                // maybe throw an exception here, depending on your needs. 
                return new MyClass(); // unknown item
        }
    }
