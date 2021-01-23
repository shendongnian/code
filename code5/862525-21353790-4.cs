    public class JobService
    {
        private readonly IRepository _repository;
        // New Constructor with will make _repository null
        public JobService()
        {           
        }
        public JobService(IRepository repository)
        {
            _repository = repository;
        }
        public Job CreateJobBanker()
        {
            var banker = new Job();
            string id = Guid.NewGuid().ToString("N");
            Console.WriteLine("Novo job banker id: {0}", id);
            banker.Id = id;
            banker.Type = JobType.Banker;
            banker.CreatedAt = DateTime.Now;
            Console.WriteLine("Salvando job banker id: {0}", id);
           
            // NullReferenceException if you define a parameterless constructor
            Job jobBanker = _repository.SaveJob(banker);
            return jobBanker;
        }
    }
