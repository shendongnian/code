    public class MyAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
     {
                
            public Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
            {
                     if (context.Principal != null && context.Principal.Identity.IsAuthenticated)
                     {
                           CustomPrincipal myPrincipal = new CustomPrincipal();
                
                           // Do work to setup custom principal
                                
                           context.Principal = myPrincipal;
                     }
                   return Task.FromResult(0);
     }
