    JobObject[] jobs = ...; // init array of jobs
    Parallel.ForEach(jobs, 
                 new ParallelOptions { MaxDegreeOfParallelism = PARALLELISM},
                (job) => 
                {
                    using(SqlConnection connection = new SqlConnection(_connectionString)
                    {
                        job.Do(connection);
                    }
                });
