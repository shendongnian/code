    public class CombinedItem : Item
    {
       private readonly ObjectItem _objectItem = new ObjectItem();
    
       public bool IsExpanded
       {
          get { return _objectItem.IsExpanded; }
          set { _objectItem.IsExpanded = value; }
       }
    
       public ObjectItem ObjectItem
       {
          get { return _objectItem; }
       }
    
       public static implicit operator ObjectItem(CombinedItem combinedItem)
       {
          return combinedItem._objectItem;
       }
    }
    
    
    
    <Expander IsExpanded={Binding ObjectItem.IsExpanded}/>
