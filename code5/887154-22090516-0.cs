    private class LargeTransportBinding : Binding
    {
        Binding originalBinding;
        public LargeTransportBinding(Binding sourceBinding)
        {
            originalBinding = sourceBinding;
        }
        public override BindingElementCollection CreateBindingElements()
        {
            // Copy
            BindingElementCollection modifiedBindingElementCollection = originalBinding.CreateBindingElements().Clone();
            // Tweak Reader Quoters and max buffer sizes
            TextMessageEncodingBindingElement encoding = (TextMessageEncodingBindingElement)modifiedBindingElementCollection[1];
            encoding.ReaderQuotas.MaxArrayLength = int.MaxValue;
            encoding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
            encoding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
            HttpTransportBindingElement transport = (HttpTransportBindingElement)modifiedBindingElementCollection[2];
            transport.MaxBufferPoolSize = int.MaxValue;
            transport.MaxBufferSize = int.MaxValue;
            transport.MaxReceivedMessageSize = int.MaxValue;
            return modifiedBindingElementCollection;
        }
        public override string Scheme
        {
            get { return originalBinding.Scheme; }
        }
    }
