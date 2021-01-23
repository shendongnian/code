    public class MyItemDrop : Drop
    {
      private readonly MyItem _item;
      public MyItemDrop(MyItem item)
      {
        _item = item;
      }
      public string Name
      {
        get { return _item.Name; }
      }
      public string Value
      {
        get { return _item.Value; }
      }
    }
