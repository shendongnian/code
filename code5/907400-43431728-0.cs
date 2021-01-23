    public class AuthorizeAttributeEx : AuthorizeAttribute
    {
        public override bool AuthorizeHubConnection(HubDescriptor hubDescriptor, IRequest request)
        {
            return IsUserAuthorized(request);
        }
        public override bool AuthorizeHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
        {
            return IsUserAuthorized(hubIncomingInvokerContext.Hub.Context.Request);
        }
        protected bool IsUserAuthorized(IRequest thisRequest)
        {
            try
            {
                // Within the hub itself we can get the request directly from the context.
                //Microsoft.AspNet.SignalR.IRequest myRequest = this.Context.Request; // Unfortunately this is a signalR IRequest, not a ServiceStack IRequest, but we can still use it to get the cookies.
                bool perm = thisRequest.Cookies["ss-opt"].Value == "perm";
                string sessionID = perm ? thisRequest.Cookies["ss-pid"].Value : thisRequest.Cookies["ss-id"].Value;
                var sessionKey = SessionFeature.GetSessionKey(sessionID);
                CustomUserSession session = HostContext.Cache.Get<CustomUserSession>(sessionKey);
                return session.IsAuthenticated; 
            }
            catch (Exception ex)
            {
                // probably not auth'd so no cookies, session etc.
            }
            return false;
        }
    }
