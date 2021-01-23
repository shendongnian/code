        public enum ItemType : int {
            Default = 0,
            Basic = 1,
            Advanced = 2,
            Expert = 3
        }
        public class NotSoGoodItem {
            public string Name { get; set; }
            public int Id { get; set; }
            public ItemType DataType { get; set; }
            public List<String> BasicSettings {get; set;}
            public List<String> AdvancedSettings {get; set;}
            public List<String> ExperSettings {get; set;}
        }
        public static NotSoGoodItem CreateNewItem(ItemType item) {
            //item is inherently an int
            switch (item) {
                case ItemType.Default | ItemType.Basic:
                    return new NotSoGoodItem() { Name = "Basic Item", BasicSettings = new List<String>() };
                case ItemType.Advanced:
                    return new NotSoGoodItem() { Name = "Advanced Item", AdvancedSettings = new List<String>() };
                case ItemType.Expert:
                    return new NotSoGoodItem() { Name = "Expert Item", AdvancedSettings = new List<String>() };
                default:
                    return null;
            }
        }
