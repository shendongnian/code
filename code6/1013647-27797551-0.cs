    public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
        {
            protected override Google.Apis.Auth.OAuth2.Mvc.FlowMetadata FlowData
            {
                get { return new AppFlowMetadata(); }
            }
        }
