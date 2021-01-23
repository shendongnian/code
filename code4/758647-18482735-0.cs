    public abstract class SupplierBase<TRequest, TResponse>
        {
            protected abstract TRequest generateRequest();
            protected abstract TResponse sendRequest (TRequest request);
            protected abstract CommonResponse mapResponse (TResponse request);
    
            public CommonResponse process(TRequest request)
            {
                return mapResponse(sendRequest(generateRequest()));
            }
        }
    
        // an implementing class...
        public class SupplierA:SupplierBase<RequestA, ResponseA>
        {
            protected override RequestA generateRequest()
            {
                return new RequestA();
            }
    
            protected override ResponseA sendRequest(RequestA request)
            {
                // call with the request and return the specific response
            }
    
            protected override CommonResponse mapResponse(ResponseA request)
            {
                // map the specific response to the common response
            }
        }
