       using using System.Web;
      public class RealTimeNotificationsUserIdProvider : IUserIdProvider
      {
       public string GetUserId(IRequest request)
       {
          return HttpContext.Current.User.Identity.GetUserId()
       }
     }
