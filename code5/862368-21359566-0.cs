    // The act of selecting an item is very ICommand'y, let's model it
    // as such.
    ReactiveCommand SuggestionItemSelected = new ReactiveCommand();
    // Important to *not* signal a change here by touching the field
    // so that we avoid a circular event chain
    SuggestionItemSelected.Subscribe(x => _searchTerms = x);
    // NB: Always provide a scheduler to Throttle!
    var searchTerms = this.WhenAnyValue(x => x.SearchTerms)
        .Where(x => canSearch)
        .Throttle(TimeSpan.FromMilliseconds(500), RxApp.MainThreadScheduler);
    // Select + Switch will do what you were trying to do with CombineLatest
    var latestResults = searchTerms
        .Select(SearchAirports);
        .Switch()
    // The listbox is the combination of *Either* the latest results, or the
    // empty list if someone chooses an item
    var latestResultsOrCleared = Observable.Merge(
        latestResults,
        SuggestionItemSelected.Select(_ => new List<Results>()));
    latestResultsOrCleared
        .ToProperty(this, x => x.AirportLiteWithWeights, out _airportLiteWithWeights);
