    interface IPaymentRequest
    {
        void Process(IPaymentRequestProcessor processor);
    }
    class CaptureRequest  : IPaymentRequest
    {
        public void Process(IPaymentRequestProcessor processor)
        {
            processor.Process(this);
        }
    }
    class PreAuthorizeRequest : IPaymentRequest
    {
        public void Process(IPaymentRequestProcessor processor)
        {
            processor.Process(this);
        }
    }
    interface IPaymentRequestProcessor
    {
        void Process(CaptureRequest request);
        void Process(PreAuthorizeRequest request);
    }
