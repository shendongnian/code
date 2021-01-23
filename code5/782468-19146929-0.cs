    public class DataForm {
      private GroupedItem m_item2;
      public event EventHandler Item2Changed;
      public DataForm() { // this is your constructor
        Item1 = new GroupedItem();
        Item2 = new GroupedItem();
        ItemCollection = new GroupCollectionItems("Group1");
      }
      public float Value1 { get; set; }
      public float Value2 { get; set; }
      public GroupedItem Item1 { get; set; }
      public GroupedItem Item2 {
        get { return m_item2; }
        set {
          if (m_item2 != value) {
            m_item2 = value;
            if (Item2Changed != null) {
              Item2Changed(this, EventArgs.Empty); // notify whoever is listening for the change
            }
          }
        }
      }
      public GroupCollectionItems ItemCollection { get; set; }
    }
    public class GroupedItem {
      public GroupedItem() { // this is your constructor
      }
      public string Name { get; set; }
      public object Value { get; set; }
    }
    public class GroupCollectionItem {
      private GroupCollectionItem() { // this is your constructor
      }
      public static GroupCollectionItem Create(string groupName, string itemName, object itemValue) {
        var item = new GroupCollectionItem() {
          Group = groupName,
          Name = itemName,
          Value = itemValue
        };
        return item;
      }
      public string Group { get; private set; }
      public string Name { get; private set; }
      public object Value { get; set; }
    }
    public class GroupCollectionItems : List<GroupCollectionItem> {
      public GroupCollectionItems(string name) { // this is your constructor
        Name = name;
      }
      public string Name { get; private set; }
    }
