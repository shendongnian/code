    private IDisposable HandleAddRemove<T>(
        ObservableCollection<T> collection,
        Func<T, Task> addActionAsync,
        Func<T, Task> removeActionAsync)
    {
        return Observable
            .FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                h => collection.CollectionChanged += h,
                h => collection.CollectionChanged -= h)
            .Select(evt => evt.EventArgs)
            .Where(item => item.Action == NotifyCollectionChangedAction.Add ||
                            item.Action == NotifyCollectionChangedAction.Remove)
            .Select(x => x.Action == NotifyCollectionChangedAction.Add
                                ? (T) x.NewItems[0]
                                : (T) x.OldItems[0])
            .GroupBy(item => item)
            .SelectMany(item => item.Zip(
                GetAddRemoveLoop(addActionAsync, removeActionAsync),
                (i, action) => Observable.Defer(() => action(i).ToObservable())).Concat())
            .Subscribe();
    }
