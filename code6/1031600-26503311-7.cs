    public void Method() {
        // Operation One:
        Task<int> commit = CommitAsync();
        // Operation Two.
        // At this point I'd really like to know how many records were committed.
        // This will block if the commit hasn't happened yet.
        int recordsAffected = Task.Result;
    }
