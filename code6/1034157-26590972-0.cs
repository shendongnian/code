    public Job() {
        _startDate = DateTime.UtcNow;
        // ...
    }
    
    public Job(JobData data) {
        _startDate = data.StartDate;
        //...
    }
