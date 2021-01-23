    // GET api/<controller>
    [HttpGet]
    [Route("pharmacies/{pharmacyId}/page/{page}/{filter?}")]
    public async Task<CartTotalsDTO> GetProductsWithHistory(Guid pharmacyId, int page, string filter = null ,[FromUri] bool refresh = false)
    {
            var jobID = Guid.NewGuid().ToString()
            var job = new Job
            {
                Id = jobId,
                jobType = "GetProductsWithHistory",
                pharmacyId = pharmacyId,
                page = page,
                filter = filter,
                Created = DateTime.UtcNow,
                Started = null,
                Finished = null,
                User =  {{extract user id in the normal way}}
            };
            jobService.CreateJob(job);
            var timeout = 10*60*1000; //10 minutes
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool responseReceived = false;
            do
            {
                //wait for the windows service to process the job and build the results in the results table
                if (jobService.GetJob(jobId).Finished == null)
                {
                    if (sw.ElapsedMilliseconds > timeout ) throw new TimeoutException();
                    await Task.Delay(2000);
                }
                else
                {
                    responseReceived = true;
                }
            } while (responseReceived == false);
        //this fetches the results from the temporary results table
        return jobService.GetProductsWithHistory(jobId);
    }
