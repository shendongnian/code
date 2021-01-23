    class Processor
    {
        protected virtual void OnSetSettings(IPaymentRequest request)
        {
        }
        private void SetSettings(IPaymentRequest request)
        {
            // do the common stuff
            // ...
            // set custom settings
            OnSetSettings(request);
        }
    }
    class PreAuthorizeRequestProcessor : Processor
    {
        protected override void OnSetSettings(IPaymentRequest request)
        {
            base.OnSetSettings(request);
            // set custom settings here
            var customRequest = (PreAuthorizeRequest)request;
        }
    }
