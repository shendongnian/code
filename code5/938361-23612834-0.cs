    public void ProcessResult(LazyResult<Userinfo> result)
    {
        //Do stuff
    }
---
    
    service.Userinfo.Get().FetchAsync(ProcessResult);
