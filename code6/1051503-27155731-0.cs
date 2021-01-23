    public abstract class OAuthRefreshToken<U> : OAuthRefreshToken where U : OAuthUser
    {
         public override OAuthUser User
         {
             get { return TypedUser; }
             set { TypedUser = (U) value; }
         }
    
         public virtual U TypedUser { get; set; }
    }
