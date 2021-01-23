    public async void AddItem<T>(ObservableCollection<T> oc, List<T> items)
    {
        // "lst" reference is locked here, but it wasn't locked in the event handler 
        lock (items)
        {
            // Change this to what you want
            const int maxSize = 100;
    
            // Make sure it doesn't index out of bounds
            int startIndex = Math.Max(0, items.Count - maxSize);
            int length = items.Count - startIndex;
    
            List<T> itemsToRender = items.GetRange(startIndex, length);
            
            // You can clear it here in your background thread.  The references to the objects
            // are now in the itemsToRender list.
            lst.Clear();
    
            Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
            {
                // At second look, this might need to be locked too
                lock(oc)
                {
                    oc.Clear();
    
                    for (int i = 0; i < itemsToRender.Count; i++)
                    {
                        // I didn't notice it before, but why are you checking the count again?
                        // items.Count());
                        oc.Add(items[i]);
                    }
                 }
            });
        }
    }
