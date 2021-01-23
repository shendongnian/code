    namespace xxx.Tests
    {
      public class TestableSomeClass : SomeClass
      {
        public Item TestItem {get;set;}
        public override void ChangeItem()
        {
          NewItem = TestItem;
        }
      }
    }
