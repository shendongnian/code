    [RoutePrefix("api/client/{clientId}/Payment")]
    public class PaymentController
    {
        // this uses conventional route
        public PaymentModel Get(Guid id)
        {
            ...
        }
        
        [HttpGet, Route("sale/{id}")]
        public PaymentActivityModel Sale(Guid id)
        {
            ...
        }
    }
