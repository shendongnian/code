    public static class Dummy { 
        public static ItemCollection ToItemCollection(this IEnumerable<Item> Items)
        {
            var ic = new ItemCollection();
            ic.AddRange(Items);
            return ic;
        }
    }
