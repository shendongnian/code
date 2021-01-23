    public static void MySort<TSource,TKey>(this ObservableCollection<TSource> observableCollection, Func<TSource, TKey> keySelector)
        {
            var a = observableCollection.OrderBy(keySelector).ToList();
            observableCollection.Clear();
            foreach(var b in a)
            {
                observableCollection.Add(b);
            }
        }
