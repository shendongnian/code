    public class UsersOnlineModule : IHttpModule
    {
        public void Init(HttpApplication context) {
            context.PreRequestHandlerExecute += (s, e) => {
                var handler = Global.GetInstance<UsersOnlineHandler>();
                handler.Handle();
            };
        }
    }
