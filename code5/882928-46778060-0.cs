    namespace MyNamespace
    {
        [Service(Label = "My Label", Permission = "android.permission.BIND_VPN_SERVICE")]
        public class MyService : VpnService
        {
            ...
        }
    }
