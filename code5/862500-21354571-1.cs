    class Program
    {
        public class Inventory : List<Item>
        {
            public int Weight { get; set; } 
            // some other properties 
        }
        public class Item : IEquatable<Item>
        {
            public string Name { get; set; }
            public int Value { get; set; }
            public bool Equals(Item other)
            {
                return this.Name == other.Name; 
            }
        }
        public class ItemsComparer : IEqualityComparer<Item>
        {
            public bool Equals(Item x, Item y)
            {
                if (x.Name.Equals(y.Name)) return true;
                return false; 
            }
            public int GetHashCode(Item obj)
            {
                return 0; 
            }
        }
 
        public class CraftingRecipe
        {
            private List<Item> _recipe;
            private Item _outputItem; 
            public CraftingRecipe(List<Item> recipe, Item outputItem)
            {
                _recipe = recipe;
                _outputItem = outputItem; 
            }
            public Item CraftItem(Inventory inventory)
            {
                if (_recipe == null)
                {
                    //throw some ex
                }
                var commonItems = _recipe.Intersect(inventory, new ItemsComparer()).ToList();
                if (commonItems.Count == _recipe.Count)
                {
                    inventory.RemoveAll(x => commonItems.Any(y => y.Name == x.Name));
                    return _outputItem; 
                }
                return null; 
            }
        }
        static void Main(string[] args)
        {
            List<Item> recipeItems = new List<Item>() 
                { 
                    new Item { Name = "Sword" } ,
                    new Item { Name = "Magic Stone" }
                }; 
            Item outputItem = new Item() { Name ="Super magic sword" }; 
            Inventory inventory = new Inventory() 
                { 
                    new Item { Name = "Sword" } ,
                    new Item { Name = "Ring" },
                    new Item { Name = "Magic Stone" }
                };
            CraftingRecipe craftingRecipe =
                new CraftingRecipe(recipeItems, outputItem);
            var newlyCraftedItem = craftingRecipe.CraftItem(inventory);
            if (newlyCraftedItem != null)
            {
                Console.WriteLine(newlyCraftedItem.Name);
            }
            else
            {
                Console.WriteLine("Your item has not been crafted"); 
            }
            Console.Read(); 
        }
