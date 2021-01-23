    public class DataTask : IRegisteredObject
    {
         private readonly IGlobalData _global;
         private readonly IDataService _service;
         private readonly IHubContext _hub;
         private Timer _timer;
         public DataTask(IGlobalData global, IDataService service, IHubContext hub)
         {
              this._global = global;
              this._service = service;
              this._hub = hub;
              var interval = new TimeSpan(0, 0, 10);
              this._timer = new Timer(updateClients, null, TimeSpan.Zero, interval);
              // register this task with asp.net
              HostingEnvironment.RegisterObject(this);
         }
         public void Stop(bool immediate)
         {
              _timer.Dispose();
              
              HostingEnvironment.UnregisterObject(this);
         }
         private async void updateClients(object state)
         {
              var result = await this._service.GetData();
              // call the hub
              this._hub.Clients.All.updateData(result);
         }
    }
