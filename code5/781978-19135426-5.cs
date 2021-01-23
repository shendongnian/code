    IObservable<IEnumerable<ChangeDTO>> allItems = 
    Observable.FromEventPattern<CollectionChangedEventArgs>(
        x => source.CollectionChanged += x,
        x => source.CollectionChanged-= x)
        .Select(i => new ChangeDTO(source.SelectedItems, true, null)});
    IObservable<IEnumerable<ChangeDTO>> updatedItem = 
    Observable.FromEventPattern<PropertyChangedEventArgs>(
        x => source.PropertyChanged += x,
        x => source.PropertyChanged -= x).
        .Select(i => new ChangeDTO(new[] {source.Item}, false, source.UpdatedProperties));
    var collectUpdatedItems = allItems
        // We only need to know the CCE happened, not the details of it, so convert to Units
        .Select(_ => Unit.Default)
        // We must insert an event so PCEs are buffered before the first CCE
        .StartWith(Unit.Default)
        // Here we create a new PCE buffer stream at the start and after each CCE
        .Select(_ => updateItem.Buffer(TimeSpan.FromMilliseconds(300)))
        // On a CCE, switch to the new PCE buffer stream, dropping the current PCE buffer
        .Switch()
        // Finally drop any empty buffers
        .Where(i => i.Count > 0);
    // merge the CollectionChangedEvents with the PropertyChangedEvent buffers
    return collectionUpdateItems.Merge(allItems.Select(i => new List<ChangeDTO> {i}));
