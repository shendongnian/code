    public static IEnumerable<Job> GetJobEnumerator()
    {
       Job job;
       while((job = pollForJob()) != null)
       {
           yield return job;
       }
    }
