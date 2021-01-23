    public class BusinessController : Controller
    {
        private IPartnerService _partnerService;
        public BusinessController()
        {
            _partnerService = new DefaultPartnerService();
        }
        public ActionResult Create(Business business)
        {
            _partnerService.CreatePartner(business.PartnerId);
            return RedirectToAction("Index");
        }
    }
