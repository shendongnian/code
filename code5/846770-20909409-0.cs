    public class Order : INotifyPropertyChangedBase
    {
       public Order()
       {  
        ItemInfo =new ObservableCollection<Item>();
        ItemInfo.CollectionChanged += ItemInfo_CollectionChanged;
        }
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
             itemInfo = value;
             OnPropertyChanged("ItemInfo");
             OnPropertyChanged("TotalPrice");
    }
  }  
