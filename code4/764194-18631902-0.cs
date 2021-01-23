    [Serializable]
    [XmlInclude(typeof(ItemA))]
    [XmlInclude(typeof(ItemB))]
    public class BaseItem
    {
        public bool Value { get; set; }
    }
    
    [Serializable]
    public class ItemA : BaseItem
    {
        public string Text { get; set; }
    }
    
    [Serializable]
    public class ItemB : BaseItem
    {
        public int Number { get; set; }
    }
    
    [Serializable]
    public class ItemsArray
    {
        public BaseItem[] Items { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var array = new ItemsArray
            {
                Items = new BaseItem[]
                {
                    new ItemA { Value = true, Text = "Test" },
                    new ItemB { Value = false, Number = 7 }
                }
            };
    
            ItemsArray output;
    
            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(ItemsArray));
                serializer.Serialize(stream, array);
    
                stream.Position = 0;
                output = (ItemsArray)serializer.Deserialize(stream);
            }
        }
    }
