    using System.IO;
    using ProtoBuf;
    
    class Program
    {
        static void Main()
        {
            Item item = new Item { A = 123321 }; 
            
            var obj = new Wrapper { Item = item };
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, obj);
                ms.Position = 0;
                IItem iObj = Serializer.Deserialize<Wrapper>(ms).Item;
                Item cObj = (Item)iObj;
            }
        }
    }
    
    [ProtoContract]
    class Wrapper
    {
        [ProtoMember(1)]
        public IItem Item { get;set; }
    }
    
    [ProtoContract]
    [ProtoInclude(2, typeof(Item))]
    public interface IItem
    {
        [ProtoMember(1)]
        int A { get; set; }
    }
    
    [ProtoContract]
    public class Item : IItem
    {
        public int A { get; set; }
    }
