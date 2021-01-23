    ((ObservableCollection<TestClass>)listView.ItemsSource).CollectionChanged +=
         (s, e) =>
         {
             if (e.Action == 
                 System.Collections.Specialized.NotifyCollectionChangedAction.Add)
             {
                 listView.ScrollIntoView(listView.Items[listView.Items.Count - 1]);
             }
         };
