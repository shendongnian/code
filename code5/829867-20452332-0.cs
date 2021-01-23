    public class AuthenticationDelegationHandler : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> 
            SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // I. do some stuff to create Custom Principal
            // e.g.
            var principal = CreatePrincipal();
            ...
            // II. return execution to the framework            
            return base.SendAsync(request, cancellationToken).ContinueWith(t =>
            {
                HttpResponseMessage resp = t.Result;
                // III. do some stuff once finished
                // e.g.:
                // SetHeaders(resp, principal);
                return resp;
            });
        }
