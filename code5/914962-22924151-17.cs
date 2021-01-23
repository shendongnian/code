    var searchStream = Observable.FromEventPattern(
        s => txtSearch.TextChanged += s,
        s => txtSearch.TextChanged -= s)
        .Select(evt => txtSearch.Text)
        .Throttle(TimeSpan.FromMilliseconds(300))
        .DistinctUntilChanged()
        .ObserveOn(SynchronizationContext.Current)
        .Do(_ =>
        {
            this.parties.Clear();
            this.partyBindingSource.ResetBindings(false);
        })       
        .Select(searchTerm =>
            // Here we wrap the synchronous repository into an
            // async call. Note it's simply not enough to call
            // ToObservable(Scheduler.Default) on the enumerable
            // because this can actually still block up to the point that the
            // first result is yielded. Doing as we have here,
            // we guarantee the UI stays responsive
            Observable.Start(() =>
            {
                long partyCount;
                var foundParties = string.IsNullOrEmpty(searchTerm)
                    ? partyRepository.GetAll(out partyCount)
                    : partyRepository.SearchByNameAndNotes(searchTerm);
                return foundParties;
            }) // Note you can supply a scheduler, default is Scheduler.Default
            .SelectMany(x => x.Buffer(500).ToObservable())
            .ObserveOn(SynchronizationContext.Current))
        .Switch()
        .Subscribe(searchResults =>
        {
            this.parties.AddRange(searchResults);
            this.partyBindingSource.ResetBindings(false);
        },
        ex => { },
        () => { });  
