    public class AuthHandler : DelegatingHandler
    {
          protected override async Task<HttpResponseMessage> SendAsync(
                               HttpRequestMessage request,
                               CancellationToken cancellationToken)
          {
               //do authentication with your data storage, here I hardcode
               //just for demo
               GenericIdentity MyIdentity = new ClaimsIdentity("MyUser");
               String[] MyStringArray = {"Manager", "Teller"};
               GenericPrincipal MyPrincipal = new GenericPrincipal(MyIdentity, MyStringArray);
               //Set the authenticated principal here so that we can do authorization later.
               Thread.CurrentPrincipal = newPrincipal;
               if (HttpContext.Current != null)
                   HttpContext.Current.User = newPrincipal;
               return await base.SendAsync(request, cancellationToken);
          }
    }
