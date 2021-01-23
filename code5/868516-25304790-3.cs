    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR;
    public class MyAwesomeConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            var fromClient = request.QueryString["testQuery"];
            return base.OnConnected(request, connectionId);
        }
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            return base.OnReceived(request, connectionId, data);
        }
    }
