    using (var db = new SLICDataContext())
    {
        int JobID = db
        .JobRequests
        .Single(x => x.JobRequestID == JobRequestID)
        .Select(x => x.JobID.GetValueOrDefault(0));
        int reactiveJobId = db
        .Jobs
        .Single(x => x.JobID == JobID)
        .Select(x => x.ReactiveJobID.GetValueOrDefault(0));
        
        lnkDocument.NavigateUrl = 
          string.Format("/HeadOffice/ReactiveJobs/DocumentsUpload.aspx?ReactiveJobID={0}",
                        JobID);
    }
