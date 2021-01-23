    public class CustomerBusiness
    {
        public ICollection<JobOfferModel> GetAllJobOffersByCustomerId(int customerId)
        {
            // TODO: Fetch job offer details from persistent store
            // E.g.
            // dataContext.JobOffers.Where(x => x.CustomerId == customerId).ToList();
            throw new NotImplementedException();
        }
        public void CreateJobOffer(JobOfferModel jobOffer)
        {
            // TODO: Add job offer details in persistent store
            // E.g.
            // dataContext.JobOffers.Add(jobOffer);
        }
    }
