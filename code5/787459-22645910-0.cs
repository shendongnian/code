    public class PartnerService : Service
    {
         
        private PartnerManagementService _partnerManagementService;
        public PartnerService()
        {
            var configuration = new Configuration();
            _partnerManagementService = new PartnerManagementService(configuration);
        }
        public object Get(PartnerGet partner)
        {
            try
            {
                var partners = _partnerManagementService.getPartners();
                
                if (!partners.Any())
                {
                    return new HttpError(HttpStatusCode.NotFound, "Partners Could not be found");
                }
                return partners;
            }
            catch (Exception e)
            {
                return new HttpError(HttpStatusCode.InternalServerError, e);
            }
        }
