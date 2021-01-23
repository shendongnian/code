    private void A_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                //If index is defined; insert.
                if (e.NewStartingIndex >= 0)
                {
                    var index = e.NewStartingIndex;
                    foreach (var item in e.NewItems)
                    {
                        B.Insert(index, item as Category);
                        index++;
                    }
                }
                //Else; add.
                else
                    foreach (var item in e.NewItems)
                        B.Add(item as Category);
                break;
            case NotifyCollectionChangedAction.Move:
                //Remove old items at old index first.
                var oldIndex = e.OldStartingIndex;
                for (int i = 0; i < e.OldItems.Count; i++)
                {
                    B.RemoveAt(oldIndex);
                    oldIndex++;
                }
                //Then add new items at new index.
                var newIndex = e.NewStartingIndex;
                for (int i = 0; i < e.NewItems.Count; i++)
                {
                    B.RemoveAt(newIndex);
                    newIndex++;
                }
                break;
            case NotifyCollectionChangedAction.Remove:
                //If remove index is defined; remove at index (safe in case item reference appears in collection multiple times)
                if (e.OldStartingIndex >= 0)
                {
                    var index = e.OldStartingIndex;
                    foreach (var item in e.OldItems)
                    {
                        B.RemoveAt(index);
                        index++;
                    }
                }
                //Else remove item.
                else
                    foreach (var item in e.OldItems)
                        B.Remove(item as Category);
                break;
            case NotifyCollectionChangedAction.Replace:
                //If replace index is defined.
                if (e.NewStartingIndex >= 0)
                {
                    var index = e.NewStartingIndex;
                    foreach (var item in e.NewItems)
                    {
                        B[index] = item as Category;
                        index++;
                    }
                }
                //Else try to find index.
                else
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        var index = B.IndexOf(e.OldItems[i] as Category);
                        B[index] = e.NewItems[i] as Category;
                    }
                break;
            case NotifyCollectionChangedAction.Reset:
                //Reset collection.
                B.Clear();
                foreach (var item in sender as ObservableCollection<Category>)
                    B.Add(item);
                break;
        }
    }
