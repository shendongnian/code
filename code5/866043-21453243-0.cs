    public class ServiceRoleAClient : ClientBase<IServiceRoleA>, IServiceRoleA
    {
       public InfoDetails GetInfo(GetInfoRequest request)
       {
          return Channel.GetInfo(request);
       }
    }
The only drawback is that you'll have to maintain the system.serviceModel node in the app.config file yourself.
