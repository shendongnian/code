    public class MyCollectionDrop : Drop
    {
      private readonly MyCollection _items;
      public MyCollectionDrop(MyCollection items)
      {
        _items = items;
      }
      public override object BeforeMethod(string method)
      {
        return _items[method];
      }
    }
