    namespace MyApp.Extensions
    {
        /// <summary>
        /// Observable collection extension.
        /// </summary>
        public static class ObservableCollectionExtension
        {
           
            /// <summary>
            /// Replaces the collection without destroy it
            /// Note that we don't Clear() and repopulate collection to avoid and UI winking
            /// </summary>
            /// <param name="collection">Collection.</param>
            /// <param name="newCollection">New collection.</param>
            /// <typeparam name="T">The 1st type parameter.</typeparam>
            public static void UpdateCollection<T>(this ObservableCollection<T> collection, IEnumerable<T> newCollection)
            {
                IEnumerator<T> newCollectionEnumerator = newCollection.GetEnumerator();
                IEnumerator<T> collectionEnumerator = collection.GetEnumerator();
    
                Collection<T> itemsToDelete = new Collection<T>();
                while( collectionEnumerator.MoveNext())
                {
                    T item = collectionEnumerator.Current;
    
    				// Store item to delete (we can't do it while parse collection.
    				if( !newCollection.Contains(item)){
                        itemsToDelete.Add(item);
                    }
                }
    
                // Handle item to delete.
                foreach( T itemToDelete in itemsToDelete){
                    collection.Remove(itemToDelete);
                }
    
                var i = 0;
    			while (newCollectionEnumerator.MoveNext())
    			{
                    T item = newCollectionEnumerator.Current;
    
    				// Handle new item.
    				if (!collection.Contains(item)){
                        collection.Insert(i, item);
    				}
    
    				// Handle existing item, move at the good index.
    				if (collection.Contains(item)){
                        int oldIndex = collection.IndexOf(item);
                        collection.Move(oldIndex, i);
    				}
    
    				i++;
    			}
            }
        }
    }
