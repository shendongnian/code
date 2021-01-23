    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {
         public AppUser CurrentUser
         {
              get
              {
                  return new AppUser(this.User as ClaimsPrincipal);
               }
         }
     }
