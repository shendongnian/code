    var searchStream = Observable.FromEventPattern(
        s => txtSearch.TextChanged += s,
        s => txtSearch.TextChanged -= s)
        .Throttle(TimeSpan.FromMilliseconds(300))
        .Select(evt => txtSearch.Text)
        .DistinctUntilChanged()
        // placement of this is important to avoid races updating the UI
        .ObserveOn(SynchronizationContext.Current)
        .Do(_ =>
        {
            // I like to use Do to make in-stream side-effects explicit
            this.parties.Clear();
            this.partyBindingSource.ResetBindings(false);
        })
        .Select(searchTerm =>
        {
            long partyCount;
            var foundParties = string.IsNullOrEmpty(searchTerm)
                ? partyRepository.GetAll(out partyCount)
                : partyRepository.SearchByNameAndNotes(searchTerm);
            // I assume the intention of the Buffer was to load
            // the data into the UI in batches. If so, you can use Buffer from nuget
            // package Ix-Main like this to get IEnumerable<T> batched up
            // without splitting it up into unit sized pieces first
            return foundParties
                // this ToObs gets us into the monad
                // and returns IObservable<IEnumerable<Party>>
                .ToObservable()
                // the ToObs here gets us into the monad from
                // the IEnum<IList<Party>> returned by Buffer
                // and the SelectMany flattens so the output
                // is IObservable<IList<Party>>
                .SelectMany(x => x.Buffer(500).ToObservable())
                // placement of this is again important to avoid races updating the UI
                .ObserveOn(SynchronizationContext.Current); 
        })
        // This cancels a pending set of batched results
        // if superceded by a textbox change (it's the equivalent
        // of your TakeUntil, but a bit neater)
        .Switch() 
        .Subscribe(searchResults =>
        {
            this.parties.AddRange(searchResults);
            this.partyBindingSource.ResetBindings(false);
        },
        ex => { },
        () => { });
