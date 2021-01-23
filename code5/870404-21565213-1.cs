    public class OtherClass
    { 
        public Item Get(ItemId id)
        {
             return Factory.Get(i => i.id == id);
        }
    }
