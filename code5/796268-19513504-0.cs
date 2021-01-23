    public class AuthHandler : DelegatingHandler{
    
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
        //authenticate user
        //get claims
        //create principal
        var newPrincipal = CreatePrincipal(claims);
        Thread.CurrentPrincipal = newPrincipal;
        if (HttpContext.Current != null)
             HttpContext.Current.User = newPrincipal;
        return await base.SendAsync(request, cancellationToken);
        }
    }
