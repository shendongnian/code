    interface IPaymentRequest<TTransaction>
        where TTransaction : ITransaction
    {
        string Token { get; set; }
        int ClientID { get; set; }
        TTransaction Transaction { get; set; }
    }
    class Processor<TRequest, TTransaction>
        where TRequest : IPaymentRequest<TTransaction>
        where TTransaction : ITransaction
    {
        protected virtual void OnSetSettings(TRequest request)
        {
        }
        private void SetSettings(TRequest request)
        {
            // do the common stuff
            // ...
            // set custom settings
            OnSetSettings(request);
        }
    }
    class PreAuthorizeRequestProcessor : Processor<PreAuthorizeRequest, PreAuthTransaction>
    {
        protected override void OnSetSettings(PreAuthorizeRequest request)
        {
            base.OnSetSettings(request);
            // set custom settings here
        }
    }
