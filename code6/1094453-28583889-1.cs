    interface IResourceProperties
    {
    }
    
    class TopLevelResource<T> 
    where T: IResourceProperties
    {
    
    }
    
    class Camera: TopLevelResource<CameraProperties>, IResourceProperties
    {
    }
    
    class CameraProperties : IResourceProperties
    {
    }
    
    class Phone: TopLevelResource<PhoneProperties>, IResourceProperties
    {
    }
    
    class PhoneProperties : IResourceProperties
    {
    }
    
    
    
        class Program
        {static void DoSomething<T>
            (List<T> items) where T : IResourceProperties
        {
      return;
    }
            static void Main(string[] args)
            {
                 List<Camera> cameras = new List<Camera>();
     List<Phone> phones = new List<Phone>();
     DoSomething(cameras);
     DoSomething(phones);
            }
