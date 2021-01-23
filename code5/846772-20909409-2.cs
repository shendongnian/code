    public class Order : INotifyPropertyChangedBase
    {
    void ItemInfo_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("TotalPrice");
        }
       private ObservableCollection<Item> itemInfo;
       public ObservableCollection<Item> ItemInfo 
       { 
         get { return itemInfo; }
         set 
         {
             if(itemInfo!=null)
                 itemInfo.CollectionChanged -= ItemInfo_CollectionChanged;
             
             itemInfo = value;
             if(itemInfo!=null)
                 itemInfo.CollectionChanged += ItemInfo_CollectionChanged;
             OnPropertyChanged("ItemInfo");
             OnPropertyChanged("TotalPrice");
    }
   }
