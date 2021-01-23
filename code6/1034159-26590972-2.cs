    public Job() {
        _lastUpdated = DateTime.UtcNow;
        // ...
    }
    
    public Job(JobData data) {
        _lastUpdated = data.LastUpdated;
        //...
    }
