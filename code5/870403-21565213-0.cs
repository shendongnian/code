    public class OtherClass
    { 
        public Item Get(ItemId id){
             Return Factory.Get(i => i.id == id);
        }
    }
