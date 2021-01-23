    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
    
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
    
        public IEnumerable<Job> GetAllJobs()
        {
            return _jobRepository.All().OrderBy(x => x.Name);
        }
    
        public Job GetJobById(Guid Id)
        {
            return _jobRepository.FindBy(x => x.Id == Id);
        }
    
        public void UpdateJob(Job job, User user)
        {
            job.LastUpdatedDate = DateTime.Now;
            job.LastUpdatedBy = user;
    
            _jobRepository.Update(job);
        }
    
        public void DeleteJob(Job job)
        {
            _jobRepository.Delete(job);
        }
    
        public void SaveJob(Job job, User user)
        {
            job.CreatedDate = DateTime.Now;
            job.CreatedBy = user;
    
            _jobRepository.Insert(job);
        }
    }
