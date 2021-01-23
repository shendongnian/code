    public class Service1 : IService1
    {
      ...
    }
    public class Service2 : IService2
    {
      ...
    }
    ServiceHost serviceHost1 = new ServiceHost(typeof(Service1));
    serviceHost1.Open();
    ServiceHost serviceHost2 = new ServiceHost(typeof(Service2));
    serviceHost2.Open();
