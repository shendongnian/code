     public List<Countries> getSharedCountries(string brandName)
                {
                    var items = SharedJobs.Where(a => a.BrandName == brandName);
            
                    var items2 = items.OrderBy(a => a.CountryCode);
            
                    Countries = new List<Countries>();
            
                    string Country = null;
            
                    foreach (var item in items2)
                    {
                        if (Country != item.CountryCode)
                        {
                            Country = item.CountryCode;
                            foreach (var jobDetail in getSharedJob(item.CountryCode))
                            {
                               Countries.Add(new Countries() { CountryCode = item.CountryCode, JobIDs = jobDetail.JobID });
                             }
                        }
    
                    }
                    return Countries;
                }
            
                public List<JobDetail> getSharedJob(string Country)
                {
                    var items = SharedJobs.Where(a => a.CountryCode == Country);
            
                    JobNetDetails = new List<JobDetail>();
                    CareerBoardDetails = new List<JobDetail>();
                    JobSharkDetails = new List<JobDetail>();
                    JobServeDetails = new List<JobDetail>();
            
                    int AusCount = 0;
            
                    foreach (var item in items)
                    {
                        if (Country == "AUS")
                        {
                            AusCount++;
            
                            if (AusCount % 4 == 0)
                            {
                                JobNetDetails.Add(new JobDetail() { JobPageTitle = item.JobPageTitle, JobID = item.JobID, JobUrl = item.JobUrl });
                            }
                            else
                            {
                                JobServeDetails.Add(new JobDetail() { JobPageTitle = item.JobPageTitle, JobID = item.JobID, JobUrl = item.JobUrl });
                            }
                        }
                    }
        
                  return JobServeDetails;
                }
