    private void OnInitialiseConnection()
    {
        // ... your connection logic
        // reinitialise the subject...
        results = Subject.Synchronize(new Subject<Tuple<int,IResult>>());
    }
