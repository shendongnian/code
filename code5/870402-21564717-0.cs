    public class OtherClass
    {
        public Item Get(ItemId id)
        {
           return Factory.Items.SingleOrDefault(i => i.ID == id);
        }
    }
