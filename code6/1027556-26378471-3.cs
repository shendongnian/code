    public class Service : ApiController
    {
        PriceApplication priceApp = new PriceApplication();
        [HttpGet]
        public int UpdatePrice(int priceId,int cost,DateTime lastUpdate)
        {
            try
            {
                var price = priceApp.GetByPriceId(priceId);
                price.Cost = Convert.ToDecimal(cost);
                price.LastUpdate = lastUpdate;
                priceApp.Update(price);
                return cost;
            }
            catch
            {
                return -1;
            }
        }
    }
