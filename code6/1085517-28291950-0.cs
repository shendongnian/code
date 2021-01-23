     private static void CollectionOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
     {
         if (notifyCollectionChangedEventArgs.Action == NotifyCollectionChangedAction.Add)
         {
             ObservableCollection<int> myCollection = sender as ObservableCollection<int>;
             if(myCollection != null){
                 //do whatever you want
             }
         }
     }
