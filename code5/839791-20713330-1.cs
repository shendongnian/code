    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Clean<int>> myCollection = new    ObservableCollection<Clean<int>>();
            myCollection.CollectionChanged += x_CollectionChanged;
    
            myCollection.Add(new Clean<int>(2,false));
    
        }
    
        static void x_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //Grab the collection being modified
            ObservableCollection<Clean<int>> collection = sender as ObservableCollection<Clean<int>>;
            if (collection == null)
            {
                // do some error checking action
            }
            //Only look at items being added
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                //New item has been added
                foreach (Clean<int> newItem in e.NewItems)
                {
                    ///Only perform the operation on new "dirty" objects
                    if (!newItem.IsClean)
                    {
                        collection.Remove(newItem);
                        //Add the new modified value and mark it as clean so that 
                        //    this process isn't run again
                        collection.Add(new Clean<int>(newItem.Value * 2,true));
                    }
                }
            }
    
        }
    }
