        public class CustomerController : Controller
        {
        public CustomerBusiness customerBusiness { get; set; }
        public CustomerController()
        {
            customerBusiness = new CustomerBusiness();
        }
        //Some code that makes CRUD and more these methods
        [HttpGet]
        public ActionResult ViewAllJobOffersForCustomer(int customerId)
        {
            ICollection<JobOfferModel> model = customerBusiness.GetAllJobOffersByCustomerId(customerId);
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateJobOffer()
        {
            // Blank model object to accept values from user, 
            // you may like to create a view model based on UI needs.
            JobOfferModel jobOfferModel = new JobOfferModel();
            return View(jobOfferModel);
        }
         [HttpPost]
         public ActionResult CreateJobOffer(JobOfferModel jobOffer)
         {
             // You get a filled object here that contains customer id and job offer details
             customerBusiness.CreateJobOffer(jobOffer);
             return RedirectToAction("ViewAllJobOffersForCustomer", new { customerId = jobOffer.CustomerId });
         }
