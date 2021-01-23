        [RoutePrefix("paypal")]
        public class PayPalController : ApiController
        {
            private PayPalValidator _validator;
    
            public PayPalController()
            {
               this._validator = new PayPalValidator();
            }
    
            [HttpPost]
            [Route("ipn")]
            public void ReceiveIPN(IPNBindingModel model)
            {
                if (!_validator.ValidateIPN(model.RawRequest)) 
                    throw new Exception("Error validating payment");
    
                switch (model.PaymentStatus)
                {
    
                    case "Completed":
                        //Business Logic
                        break;
                }
           }
        }
