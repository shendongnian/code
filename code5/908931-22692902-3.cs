    public class BondsController : ApiController
    {
        [Route("api/bonds/get-bond-without-price/{id}")]
        public PricelessBond GetBondWithoutPrice(int id)
        {
            return DataAccess.GetBondWithoutPrice(id);
        }
        [Route("api/bonds/get-bond/{id}")]
        public Bond GetBond()
        {
            return DataAccess.GetBond(id);
        }
    }
