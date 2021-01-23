    public class CombinedItem : Item
    {
       private readonly ObjectItem _objectItem = new ObjectItem();
       public CombinedItem()
       {
           _objectItem.PropertyChanged += (s, e) => 
           {
               if (e.PropertyName == "IsExpanded")
                   OnPropertyChanged("IsExpanded");
           }
       }
    
       public bool IsExpanded
       {
          get { return _objectItem.IsExpanded; }
          set { _objectItem.IsExpanded = value; }
       }
    
       public static implicit operator ObjectItem(CombinedItem combinedItem)
       {
          return combinedItem._objectItem;
       }
    }
