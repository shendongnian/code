    public class DefaultPartnerService : IPartnerService
    {
        private StoreContext db;
        public DefaultPartnerService()
        {
            db = new StoreContext();
        }
        public void CreatePartner(int partnerId)
        {
            // Something interesting
        }
    }
