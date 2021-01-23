        public void Dispose()
        {
            // check if object has IDisposble implemented
            IDisposable disposePricing = pricingEnvironment as IDisposable;
            if (disposePricing!=null)
            {
                disposePricing.Dispose();
            }
        }
