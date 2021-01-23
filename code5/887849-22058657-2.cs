     class PossibleItems
        {
            public class Item
            {
                public readonly string Name;
                public readonly string Description;
                public Item(string name, string desc)
                {
                    this.Name = name;
                    this.Description = desc;
                }
            }
            public static List<Item> Get()
            {
                List<Item> list = new List<Item>();
                list.Add(new Item("name1", "desc1"));
                list.Add(new Item("name2", "desc2"));
                return list;
            }
        }
