    public HttpResponseMessage Post(JobRequest request) 
    {
        // ... model validation, other checks
        // create job object
        var job = new Job { Name = request.Name, Candidates = new Collection<Candidate>() };
    
        // associate existing candidates to the job
        foreach(var candidate in request.Candidates) {
            var c = new Candidate { Id = candidate.Id};
            context.Candidates.Attach(c);   // without this, EF will try to create new Candidate
            job.Candidates.Add(c);    // associate the existing candidate with the job
        }
    
        context.Jobs.Add(job);      // add the job
        context.SaveChanges();      // save
        
        // ... handle errors, return status codes etc.
    
    }
