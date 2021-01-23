    public async void AddItem<T>(ObservableCollection<T> oc, List<T> items)
    {
        // "lst" reference is locked here, but it wasn't locked in the event handler 
        lock (items)
        {
            if (Dispatcher.HasThreadAccess)
            {
                foreach (T item in items)
                    oc.Add(item);
            }
            else
            {
                Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
                {
                    oc.Clear();
                    
                    // This may never exit the for loop
                    for (int i = 0; i < items.Count; i++)
                    {
                        items.Count());
                        oc.Add(items[i]);
                    }
                    lst.Clear();
                });
            }
        }
    }
