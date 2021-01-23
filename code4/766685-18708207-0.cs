    var context = GlobalHost.ConnectionManager.GetHubContext<TiHub>();
    var tasks = (from kp in Sessions
                 let client = context.Clients.Client(kp.Key)
                 where client != null
                 select Task.Run(() =>
                     {
                         client.changed(new Data{ data = somevaluekp.Value);
                     })).ToArray();
    
    await Task.WhenAll(tasks);
