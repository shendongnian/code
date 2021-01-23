    public class StructureMapServiceBehavior : BehaviorExtensionElement, IServiceBehavior
    {
      public void ApplyDispatchBehavior(ServiceDescription desc, ServiceHostBase host)
      {
    
        foreach (ChannelDispatcherBase cdb in host.ChannelDispatchers)
        {
          var cd = cdb as ChannelDispatcher;
          if (cd != null)
          {
            foreach (EndpointDispatcher ed in cd.Endpoints)
            {
              ed.DispatchRuntime.InstanceProvider =
              new StructureMapInstanceProvider(desc.ServiceType);
            }
          }
        }
        
        Bootstrapper.ConfigureBindings();
              
      }
      
      ...
    
    }
